using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetProductsByBrandHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductByBrandQuery, IList<ProductResponse>>
{
    public async Task<IList<ProductResponse>> Handle(GetProductByBrandQuery request,
        CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductByBrand(request.BrandName);
        var productResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(products);
        return productResponse;
    }
}