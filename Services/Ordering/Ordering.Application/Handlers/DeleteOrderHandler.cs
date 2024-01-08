using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commands;
using Ordering.Application.Exceptions;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class DeleteOrderHandler(IOrderRepository orderRepository, ILogger<DeleteOrderHandler> logger)
    : IRequestHandler<DeleteOrderCommand>
{
    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToDelete = await orderRepository.GetByIdAsync(request.Id);

        if (orderToDelete == null)
        {
            logger.LogError("Order {OrderId} is not found.", request.Id);
            throw new OrderNotFoundExtension(nameof(Order), request.Id);
        }

        await orderRepository.DeleteAsync(orderToDelete);
        logger.LogInformation("Order {OrderId} is successfully deleted.", request.Id);
    }
}