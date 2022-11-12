using Microsoft.AspNetCore.Mvc;
using Shopping.Api.Data.ValueObject;
using Shopping.Api.Repository;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAll();

            if (products == null) return NoContent();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
        {
            var product = await _repository.Create(vo);

            if (product == null) return BadRequest();

            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {
            var product = await _repository.Update(vo);

            if (product == null) return BadRequest();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            var product = await _repository.Delete(id);

            if (!product) return BadRequest();

            return Ok();
        }
    }
}