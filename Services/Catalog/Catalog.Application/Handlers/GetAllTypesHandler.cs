using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllTypesHandler(ITypesRepository typesRepository)
    : IRequestHandler<GetAllTypesQuery, IList<ProductTypeResponse>>
{
    public async Task<IList<ProductTypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
    {
        var typesList = await
            typesRepository.GetAllTypes();
        var typesResponse = ProductMapper.Mapper.Map<IList<ProductTypeResponse>>(typesList);
        return typesResponse;
    }
}