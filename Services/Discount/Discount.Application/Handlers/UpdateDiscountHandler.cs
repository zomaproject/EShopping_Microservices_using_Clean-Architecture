using Discount.Application.Commands;
using Discount.Application.Mappers;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class UpdateDiscountHandler(IDiscountRepository discountRepository)
    : IRequestHandler<UpdateDiscountCommand, CouponModel>
{
    public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = DiscountMapper.Mapper.Map<Coupon>(request);
        var result = await discountRepository.UpdateDiscount(coupon);
        if (!result)
            throw new RpcException(new Status(StatusCode.Internal,
                $"Discount with ProductName={request.ProductName} is not updated."));
        return DiscountMapper.Mapper.Map<CouponModel>(coupon);
    }
}