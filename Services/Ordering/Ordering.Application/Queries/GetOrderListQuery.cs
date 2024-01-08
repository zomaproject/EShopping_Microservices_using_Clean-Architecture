using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Queries;

public class OrderListQuery(string userName) : IRequest<List<OrderResponse>>
{
    public string UserName { get; set; } = userName;
}