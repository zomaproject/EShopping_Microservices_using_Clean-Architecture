using Dapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Infrastructure.Repositories;

public class DiscountRepository(IConfiguration configuration) : IDiscountRepository
{
    public async Task<Coupon> GetDiscount(string productName)
    {
        await using var connection =
            new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        const string sql = "SELECT * FROM Coupon WHERE ProductName = @ProductName";
        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(sql, new { ProductName = productName });
        return coupon ?? new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        await using var connection =
            new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        const string sql =
            "INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)";
        var affected =
            await connection.ExecuteAsync(sql, new { coupon.ProductName, coupon.Description, coupon.Amount });
        return affected > 0;
    }

    public async Task<bool> UpdateDiscount(Coupon coupon)
    {
        await using var connection =
            new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        const string sql =
            "UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id";
        var affected =
            await connection.ExecuteAsync(sql,
                new { coupon.ProductName, coupon.Description, coupon.Amount, coupon.Id });
        return affected > 0;
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        await using var connection =
            new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        const string sql = "DELETE FROM Coupon WHERE ProductName = @ProductName";
        var affected = await connection.ExecuteAsync(sql, new { ProductName = productName });
        return affected > 0;
    }
}