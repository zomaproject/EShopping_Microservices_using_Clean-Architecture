﻿using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Handlers;

public class GetBasketByUserNameHandler(IBasketRepository basketRepository)
    : IRequestHandler<GetBasketByUserNameQuery, ShoppingCartResponse>
{
    public async Task<ShoppingCartResponse> Handle(GetBasketByUserNameQuery request,
        CancellationToken cancellationToken)
    {
        var shoppingCart = await basketRepository.GetBasket(request.UserName);
        return BasketMapper.Mapper.Map<ShoppingCartResponse>(shoppingCart);
    }
}