﻿using AutoMapper;
using DiscountGRPC.Repositories;
using DiscountGRPC.Protos;
using Grpc.Core;
using DiscountGRPC.Entities;

namespace DiscountGRPC.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly IDiscountRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<DiscountService> _logger;

    public DiscountService(IDiscountRepository repository, IMapper mapper, ILogger<DiscountService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }


    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _repository.GetDiscountAsync(request.ProductName);

        if (coupon == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound,
                 $"Discount with ProductName = {request.ProductName} not found."));
        }

        _logger.LogInformation("Discount retrieved for ProductName : {productName}, "
            + "Amount : {amount}", coupon.ProductName, coupon.Amount);

        var couponModel = _mapper.Map<CouponModel>(coupon);
        return couponModel;
    }


    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = _mapper.Map<Coupon>(request.Coupon);
        await _repository.CreateDiscountAsync(coupon);

        var couponModel = _mapper.Map<CouponModel>(coupon);
        return couponModel;
    }


    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = _mapper.Map<Coupon>(request.Coupon);
        await _repository.UpdateDiscountAsync(coupon);

        var couponModel = _mapper.Map<CouponModel>(coupon);
        return couponModel;
    }


    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        bool deleted = await _repository.DeleteDiscountAsync(request.ProductName);

        var response = new DeleteDiscountResponse
        {
            Success = deleted
        };

        return response;
    }
}
