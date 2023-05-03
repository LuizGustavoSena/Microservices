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
        public async Task<bool> ApplyCoupon(string userid, string coupenCode)
        {
            var header = await _context.CartHeaders
                .FirstOrDefaultAsync(c => c.UserId == userid);

            if (header == null)
                return false;

            header.CouponCode = coupenCode;
            _context.CartHeaders.Update(header);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await _context.CartHeaders
                        .FirstOrDefaultAsync(el => el.UserId == userId);

            if (cartHeader == null)
                return false;

            _context.CartDetails
                .RemoveRange(
                    _context.CartDetails.Where(el => el.CartHeader.Id == cartHeader.Id)
                );

            _context.CartHeaders.Remove(cartHeader);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CartVO> FindCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await _context.CartHeaders
                    .FirstOrDefaultAsync(el =>
                        el.UserId == userId
                    ),
            };

            cart.CartDetails = _context.CartDetails
                .Where(el => el.CardHeaderId == cart.CartHeader.Id)
                .Include(el => el.Product);

            return _mapper.Map<CartVO>(cart);
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            var header = await _context.CartHeaders
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (header == null)
                return false;

            header.CouponCode = "";
            _context.CartHeaders.Update(header);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveFromCart(long cartDetailsid)
        {
            try
            {
                var cartDetails = await _context.CartDetails
                .FirstOrDefaultAsync(el => el.Id == cartDetailsid);

                int total = _context.CartDetails
                    .Where(el => el.CardHeaderId == cartDetails.CardHeaderId)
                    .Count();

                if (total == 1)
                {
                    var cartHeaderToRemove = await _context.CartHeaders
                        .FirstOrDefaultAsync(el => el.Id == cartDetails.CardHeaderId);

                    _context.CartHeaders.Remove(cartHeaderToRemove);
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

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
                var cartDetail = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(el =>
                    el.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
                    el.CardHeaderId == cartHeader.Id);

                if (cartDetail == null)
                {
                    cart.CartDetails.FirstOrDefault().CardHeaderId = cartHeader.Id;
                    cart.CartDetails.FirstOrDefault().Product = null;

                    _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());

                    await _context.SaveChangesAsync();
                }
                else
                {
                    cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                    cart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
                    cart.CartDetails.FirstOrDefault().CardHeaderId = cartDetail.CardHeaderId;

                    _context.CartDetails.Update(cart.CartDetails.FirstOrDefault());

                    await _context.SaveChangesAsync();
                }
            }

            return _mapper.Map<CartVO>(cart);
        }
    }
}