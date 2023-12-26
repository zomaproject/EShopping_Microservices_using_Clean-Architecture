﻿using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories.ProductRepository;

public class ProductRepository(ICatalogContext context) : IProductRepository, IBrandRepository, ITypesRepository
{
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await context.Products
            .Find(p => true)
            .ToListAsync();
    }

    public async Task<Product> GetProduct(string id)
    {
        return await context.Products.Find(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByName(string name)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Name, name);
        return await context.Products.Find(filter)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByBrand(string brand)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Brands.Name, brand);
        return await context.Products.Find(filter)
            .ToListAsync();
    }

    public async Task<Product> CreateProduct(Product product)
    {
        await context.Products.InsertOneAsync(product);
        return product;
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var update = await context
            .Products
            .ReplaceOneAsync(p => product.Id == p.Id, product);
        return update.IsAcknowledged && update.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProduct(string id)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
        var deleteResult = await context.Products.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<IEnumerable<ProductBrand>> GetAllBrands()
    {
        return await context.Brands.Find(p => true)
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductType>> GetAllTypes()
    {
        return await context.Types.Find(p => true)
            .ToListAsync();
    }
}