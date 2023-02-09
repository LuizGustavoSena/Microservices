using AutoMapper;
using Shopping.Car.Data.ValueObject;
using Shopping.Car.Models;
using Shopping.Car.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Shopping.Car.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;
        public CartRepository(
            MySqlContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> ApplyCoupon(string userid, string coupenCuie)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartVO> FindCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(long cartDetailsid)
        {
            throw new NotImplementedException();
        }

        public async Task<CartVO> SaveOrUpdateCart(CartVO vo)
        {
            var cart = _mapper.Map<Cart>(vo);

            var product = await _context.Products.FirstOrDefaultAsync(el =>
                el.Id == cart.CartDetails.FirstOrDefault().ProductId);

            if (product == null)
            {
                _context.Products.Add(cart.CartDetails.FirstOrDefault().Product);

                await _context.SaveChangesAsync();
            }

            var cartHeader = await _context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(el =>
                el.UserId == cart.CartHeader.UserId);

            if (cartHeader == null)
            {
                _context.CartHeaders.Add(cart.CartHeader);

                await _context.SaveChangesAsync();

                cart.CartDetails.FirstOrDefault().CardHeaderId = cart.CartHeader.Id;

                cart.CartDetails.FirstOrDefault().Product = null;

                _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());

                await _context.SaveChangesAsync();
            }
            else
            {
                var cartDetails = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(el =>
                    el.ProductId == vo.CartDetails.FirstOrDefault().ProductId &&
                    el.CardHeaderId == cartHeader.Id);

                if (cartDetails == null)
                {

                }
                else
                {

                }
            }

            return _mapper.Map<CartVO>(cart);
        }
    }
}