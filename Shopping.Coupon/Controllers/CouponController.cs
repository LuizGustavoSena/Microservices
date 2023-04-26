using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopping.Coupon.Data.ValueObjects;
using Shopping.Coupon.Repository;

namespace Shopping.Coupon.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _repository;

        public CouponController(ICouponRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{couponCode}")]
        public async Task<ActionResult<CouponVO>> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _repository.GetCouponByCouponCode(couponCode);

            if (coupon == null)
                return NotFound();

            return Ok(coupon);
        }


    }
}