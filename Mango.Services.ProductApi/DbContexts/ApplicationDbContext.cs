using Mango.Services.ProductsApi.DbContexts.Modals;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductsApi.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                CategoryName = "Kırtasite",
                Desription = "Kurşun Kalem",
                Name = "Kalem",
                ImageUrl="",
                Price = 5
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                CategoryName = "Kırtasite",
                Desription = "Pelikan",
                Name = "Silgi",
                ImageUrl = "",
                Price = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                CategoryName = "Kırtasite",
                Desription = "Harita Metod",
                Name = "Defter",
                ImageUrl = "",
                Price = 4
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
