using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllBrandsHandler(IBrandRepository brandRepository)
    : IRequestHandler<GetAllBrandsQuery, IList<ProductBrandResponse>>
{
    public async Task<IList<ProductBrandResponse>> Handle(GetAllBrandsQuery request,
        CancellationToken cancellationToken)
    {
        var brandList = await brandRepository.GetAllBrands();
        var brandResponseList =
            ProductMapper.Mapper.Map<IList<ProductBrand>, IList<ProductBrandResponse>>(brandList.ToList());
        return brandResponseList;
    }
}