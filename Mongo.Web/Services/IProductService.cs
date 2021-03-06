using Mongo.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mongo.Web.Services
{
    public interface IProductService:IBaseService
    {

        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int productId);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);

        Task<T> DeleteProductAsync<T>(int productId);



    }
}

