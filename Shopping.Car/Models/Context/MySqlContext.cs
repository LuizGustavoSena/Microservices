using Microsoft.EntityFrameworkCore;
namespace Shopping.Car.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
    }
}