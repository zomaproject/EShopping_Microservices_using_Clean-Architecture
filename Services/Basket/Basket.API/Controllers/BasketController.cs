using System.Net;
using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

public class BasketController(IMediator mediator) : ApiController
{
    [HttpGet("[action]/{userName}", Name = "GetBasketByUserName")]
    [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartResponse>> GetBasketByUserName(string userName)
    {
        var query = new GetBasketByUserNameQuery(userName);
        var basket = await mediator.Send(query);
        return Ok(basket);
    }

    [HttpPost("CreateBasket", Name = "CreateBasket")]
    [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartResponse>> UpdateBasket([FromBody] CreateShoppingCartCommand basket)
    {
        var createdBasket = await mediator.Send(basket);
        return Ok(createdBasket);
    }

    [HttpDelete("DeleteBasket/{userName}", Name = "DeleteBasket")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> DeleteBasket(string userName)
    {
        var command = new DeleteBasketByUserNameQuery(userName);
        await mediator.Send(command);
        return Ok();
    }
}