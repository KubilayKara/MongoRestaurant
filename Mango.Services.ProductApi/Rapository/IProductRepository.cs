using Mango.Services.ProductApi.Modals;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mango.Services.ProductApi.Rapository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);



    }
}
