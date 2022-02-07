using Mongo.Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mongo.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        //private readonly IHttpClientFactory _httpClient;

        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            //this._httpClient = httpClient;
            this.responseModel = new ResponseDto();
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = StaticDictionary.ApiType.POST,
                Data = productDto,
                Url = StaticDictionary.ProductApiBase + "/api/products",
                AccessToken = string.Empty

            });
        }

        public async Task<T> DeleteProductAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = StaticDictionary.ApiType.DELETE,
                Url = $"{StaticDictionary.ProductApiBase}/api/products/{productId.ToString()}",
                AccessToken = string.Empty

            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = StaticDictionary.ApiType.GET,
                Url = $"{StaticDictionary.ProductApiBase}/api/products/{productId.ToString()}",
                AccessToken = string.Empty

            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = StaticDictionary.ApiType.GET,
                Url = StaticDictionary.ProductApiBase + "/api/products",
                AccessToken = string.Empty

            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = StaticDictionary.ApiType.PUT,
                Data = productDto,
                Url = StaticDictionary.ProductApiBase + "/api/products",
                AccessToken = string.Empty

            });
        }
    }
}

