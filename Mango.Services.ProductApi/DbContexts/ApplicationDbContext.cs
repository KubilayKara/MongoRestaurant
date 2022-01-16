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
    }
}
