using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.Api.Data.ValueObject;
using Shopping.Api.Models;
using Shopping.Api.Models.Context;

namespace Shopping.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;
        public ProductRepository(
            MySqlContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVO>? Create(ProductVO vo)
        {
            var product = _mapper.Map<Product>(vo);

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var products = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

                if (products == null) return false;

                _context.Products.Remove(products);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();

            return _mapper.Map<IEnumerable<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            var products = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<ProductVO>(products);
        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            var product = _mapper.Map<Product>(vo);

            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }
    }
}