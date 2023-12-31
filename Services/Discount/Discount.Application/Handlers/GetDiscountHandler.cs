using Discount.Application.Mappers;
using Discount.Application.Queries;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class GetDiscountHandler(IDiscountRepository discountRepository) : IRequestHandler<GetDiscountQuery, CouponModel>
{
    public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var coupon = await discountRepository.GetDiscount(request.ProductName);
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with ProductName={request.ProductName} is not found."));

        return DiscountMapper.Mapper.Map<CouponModel>(coupon);
    }
}