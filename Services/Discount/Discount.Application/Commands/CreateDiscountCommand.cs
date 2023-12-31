using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Commands;

public class CreateDiscountCommand(string productName, string description, int amount) : IRequest<CouponModel>
{
    public string ProductName { get; set; } = productName;

    public string Description { get; set; } = description;

    public int Amount { get; set; } = amount;
}