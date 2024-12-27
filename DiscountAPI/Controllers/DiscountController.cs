﻿using DiscountAPI.Entities;
using DiscountAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DiscountAPI.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class DiscountController : ControllerBase
{
    private readonly IDiscountRepository _discountRepository;
    public DiscountController(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }


    [HttpGet("{productName}", Name = "GetDiscount")]
    public async Task<ActionResult<Coupon>> GetDiscount(string productName)
    {
        var coupon = await _discountRepository.GetDiscountAsync(productName);

        return Ok(coupon);
    }


    [HttpPost]
    public async Task<ActionResult<Coupon>> CreateDiscount([FromBody] Coupon coupon)
    {
        await _discountRepository.CreateDiscountAsync(coupon);

        return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);
    }


    [HttpPut]
    public async Task<ActionResult<Coupon>> UpdateDiscount([FromBody] Coupon coupon)
    {
        return Ok(await _discountRepository.UpdateDiscountAsync(coupon));
    }


    [HttpDelete("{productName}", Name = "DeleteDiscount")]
    public async Task<ActionResult<bool>> DeleteDiscount(string productName)
    {
        return Ok(await _discountRepository.DeleteDiscountAsync(productName));
    }
}
