using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public class GetProductsByBrandQuery(string brandName) : IRequest<IList<ProductResponse>>
{
    public string BrandName { get; set; } = brandName;
}