using Microsoft.AspNetCore.Mvc;
using Shopping.Car.Data.ValueObject;
using Shopping.Car.Messages;
using Shopping.Car.RabbitMQSender;
using Shopping.Car.Repository;

namespace Shopping.Car.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;
        private IRabbitMQMessageSender _rabbitMQMessageSender;

        public CartController(
            ICartRepository repository,
            IRabbitMQMessageSender rabbitMQMessageSender
            )
        {
            _repository = repository;
            _rabbitMQMessageSender = rabbitMQMessageSender;
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<IEnumerable<CartVO>>> FindById(string userid)
        {
            var cart = await _repository.FindCartByUserId(userid);

            if (cart == null) return NotFound();

            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<IEnumerable<CartVO>>> AddCart(CartVO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);

            if (cart == null) return NotFound();

            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<IEnumerable<CartVO>>> UpdateCart(CartVO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);

            if (cart == null) return NotFound();

            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<IEnumerable<Boolean>>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);

            if (!status) return BadRequest();

            return Ok(status);
        }

        [HttpPost("apply-coupon")]
        public async Task<ActionResult<IEnumerable<CartVO>>> ApplyCoupon(CartVO vo)
        {
            var status = await _repository.ApplyCoupon(vo.CartHeader.UserId, vo.CartHeader.CouponCode);

            if (!status) return NotFound();

            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<IEnumerable<CartVO>>> RemoveCoupon(string userId)
        {
            var status = await _repository.RemoveCoupon(userId);

            if (!status) return NotFound();

            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<IEnumerable<CartVO>>> Checkout(CheckoutHeaderVO vo)
        {
            if (vo.UserId == null)
                return BadRequest();

            var cart = await _repository.FindCartByUserId(vo.UserId);

            if (cart == null) return NotFound();

            vo.CartDetails = cart.CartDetails;
            vo.DateTime = DateTime.Now;

            _rabbitMQMessageSender.SendMessage(vo, "checkoutqueue");

            return Ok(vo);
        }
    }
}