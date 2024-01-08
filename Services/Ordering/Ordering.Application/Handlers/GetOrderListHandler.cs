using AutoMapper;
using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class OrderListHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<OrderListQuery, List<OrderResponse>>
{
    public async Task<List<OrderResponse>> Handle(OrderListQuery request, CancellationToken cancellationToken)
    {
        var orderList = await orderRepository.GetOrdersByUserName(request.UserName);
        return mapper.Map<List<OrderResponse>>(orderList);
    }
}