using MediatR;

namespace Basket.Application.Queries;

public class DeleteBasketByUserNameQuery(string userName) : IRequest
{
    public string UserName { get; set; } = userName;
}