using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountServices _discountServices;
        public DiscountController(IDiscountServices discountServices)
        {
            _discountServices = discountServices;
        }
        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values =await  _discountServices.GetAllDiscountCouponAsync(); 
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values= await _discountServices.GetByIdDiscountCouponAsync(id);    
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountServices.CreateDiscountCouponAsync(createCouponDto); 
            return Ok("Kupon basariyla eklendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountServices.DeleteDiscountCouponAsync(id);
            return Ok("Kupon basariyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCoupon)
        {
            await _discountServices.UpdateDiscountCouponAsync(updateCoupon);
            return Ok("Kupon basariyla guncellendi");
        }

    }
}
