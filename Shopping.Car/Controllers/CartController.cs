using Microsoft.AspNetCore.Mvc;
using Shopping.Car.Data.ValueObject;
using Shopping.Car.Repository;

namespace Shopping.Car.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
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
    }
}