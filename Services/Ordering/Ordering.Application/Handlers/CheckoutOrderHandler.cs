using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commands;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class CheckoutOrderHandler(
    IOrderRepository orderRepository,
    IMapperBase mapper,
    ILogger<CheckoutOrderHandler> logger) : IRequestHandler<CheckoutOrderCommand, int>
{
    public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var orderEntity = mapper.Map<Order>(request);
        var newOrder = await orderRepository.AddAsync(orderEntity);
        logger.LogInformation("Order {newOrder.Id} is successfully created.", newOrder.Id);
        return newOrder.Id;
    }
}