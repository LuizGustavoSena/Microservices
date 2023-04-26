using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.Coupon.Data.ValueObjects;
using Shopping.Coupon.Models.Context;

namespace Shopping.Coupon.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public CouponRepository(
            MySqlContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(el =>
                el.CouponCode == couponCode);

            return _mapper.Map<CouponVO>(coupon);
        }
    }
}