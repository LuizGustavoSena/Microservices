using Shopping.Car.Data.ValueObjects;

namespace Shopping.Car.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode, string token);
    }
}