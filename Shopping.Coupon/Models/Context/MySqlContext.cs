using Microsoft.EntityFrameworkCore;
namespace Shopping.Coupon.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}