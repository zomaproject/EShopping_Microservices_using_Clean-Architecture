using Discount.Application.Commands;
using Discount.Application.Mappers;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class CreateDiscountHandler(IDiscountRepository discountRepository)
    : IRequestHandler<CreateDiscountCommand, CouponModel>
{
    public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = DiscountMapper.Mapper.Map<Coupon>(request);

        var result = await discountRepository.CreateDiscount(coupon);
        if (!result)
            throw new RpcException(new Status(StatusCode.Internal,
                $"Discount with ProductName={request.ProductName} is not created."));
        return DiscountMapper.Mapper.Map<CouponModel>(coupon);
    }
}