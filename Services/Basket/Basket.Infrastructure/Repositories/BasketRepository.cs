using Basket.Core.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Repositories;

public class BasketRepository(IDistributedCache distributedCache) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName)
    {
        var basket = await distributedCache.GetStringAsync(userName);

        return basket == null ? null : JsonConvert.DeserializeObject<ShoppingCart>(basket);
    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
    {
        await distributedCache.SetStringAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));

        return await GetBasket(shoppingCart.UserName);
    }

    public async Task DeleteBasket(string userName)
    {
        await distributedCache.RemoveAsync(userName);
    }
}