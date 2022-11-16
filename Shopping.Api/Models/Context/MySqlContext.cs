using Microsoft.EntityFrameworkCore;

namespace Shopping.Api.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext() { }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                CategoryName = "Eletrônicos",
                Description = "Placa de video RTX 3080 Gigabyte Triple Fans",
                ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.kabum.com.br%2Fproduto%2F320817%2Fplaca-de-video-rtx-3080-gaming-oc-gigabyte-nvidia-geforce-12gb-gddr6x-rgb-lhr-dlss-ray-tracing-gv-n3080gaming-oc-12gd",
                Name = "RTX 3080",
                Price = new decimal(8.000)
            });
        }
    }
}