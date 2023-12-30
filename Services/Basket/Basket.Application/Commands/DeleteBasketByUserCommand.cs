using Basket.Application.Queries;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Handlers;

public class DeleteBasketByUserCommand(IBasketRepository basketRepository)
    : IRequestHandler<DeleteBasketByUserNameQuery>
{
    public async Task Handle(DeleteBasketByUserNameQuery request, CancellationToken cancellationToken)
    {
        await basketRepository.DeleteBasket(request.UserName);
    }
}