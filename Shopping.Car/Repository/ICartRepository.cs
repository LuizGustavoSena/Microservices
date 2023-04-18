using Shopping.Car.Data.ValueObject;

namespace Shopping.Car.Repository
{
    public interface ICartRepository
    {
        Task<CartVO> FindCartByUserId(string userId);
        Task<CartVO> SaveOrUpdateCart(CartVO cart);
        Task<bool> RemoveFromCart(long cartDetailsid);
        Task<bool> ApplyCoupon(string userid, string coupenCuie);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> ClearCart(string userId);

    }
}