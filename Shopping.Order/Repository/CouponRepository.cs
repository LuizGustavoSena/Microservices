using Microsoft.EntityFrameworkCore;
using Shopping.Order.Models;
using Shopping.Order.Models.Context;

namespace Shopping.Order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<MySqlContext> _context;

        public OrderRepository(
            DbContextOptions<MySqlContext> context
        )
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeader header)
        {
            if (header == null)
                return false;

            await using var _db = new MySqlContext(_context);

            _db.Headers.Add(header);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool status)
        {
            await using var _db = new MySqlContext(_context);

            var header = await _db.Headers.FirstOrDefaultAsync(
                el => el.Id == orderHeaderId
            );

            if (header == null)
                return;

            header.PaymentStatus = status;

            await _db.SaveChangesAsync();
        }
    }
}