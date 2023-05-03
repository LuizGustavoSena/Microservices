using System.Threading.Tasks;
using Shopping.Coupon.Data.ValueObjects;

namespace Shopping.Coupon.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode);
    }
}