using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Handlers;

public class CreateShoppingCartHandler(IBasketRepository basketRepository)
    : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
{
    public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request,
        CancellationToken cancellationToken)
    {
        // TODO: Apply coupon code
        var shoppingCart = await basketRepository.UpdateBasket(new ShoppingCart
        {
            UserName = request.UserName,
            Items = request.Items
        });

        var shoppingCartResponse = BasketMapper.Mapper.Map<ShoppingCartResponse>(shoppingCart);
        return shoppingCartResponse;
    }
}