using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductsApi.DbContexts.Modals
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1,10000)]
        public double Price { get; set; }

        public string Desription { get; set; }

        public string CategoryName { get; set; }

        public  string ImageUrl { get; set; }
    }
}
