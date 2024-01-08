using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commands;
using Ordering.Application.Extensions;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class UpdateOrderHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<UpdateOrderHandler> logger)
    : IRequestHandler<UpdateOrderCommand>
{
    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToUpdate = await orderRepository.GetByIdAsync(request.Id);

        if (orderToUpdate == null)
        {
            logger.LogError("Order {OrderId} is not found.", request.Id);
            throw new OrderNotFoundExtension(nameof(Order), request.Id);
        }

        mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));
        await orderRepository.UpdateAsync(orderToUpdate);
        logger.LogInformation("Order {OrderId} is successfully updated.", request.Id);
    }
}