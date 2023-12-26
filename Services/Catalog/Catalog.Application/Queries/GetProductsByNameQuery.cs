using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public class GetProductsByNameQuery(string name) : IRequest<IList<ProductResponse>>
{
    public string Name { get; set; } = name;
}