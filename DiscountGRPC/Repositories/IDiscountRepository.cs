﻿using DiscountGRPC.Entities;

namespace DiscountGRPC.Repositories;

public interface IDiscountRepository
{
    Task<Coupon> GetDiscountAsync(string productName);
    Task<bool> CreateDiscountAsync(Coupon coupon);
    Task<bool> UpdateDiscountAsync(Coupon coupon);
    Task<bool> DeleteDiscountAsync(string productName);
}
