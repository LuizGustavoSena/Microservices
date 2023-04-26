using Microsoft.EntityFrameworkCore;
namespace Shopping.Coupon.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<CouponC> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CouponC>().HasData(new CouponC
            {
                CouponCode = "DESCONTA10",
                DiscountAmount = 10,
                Id = 1
            });
        }
    }
}