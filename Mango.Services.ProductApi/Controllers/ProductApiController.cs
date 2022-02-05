using Mango.Services.ProductApi.Modals;
using Mango.Services.ProductApi.Rapository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductApi.Controllers
{
    [Route("api/products")]
    public class ProductApiController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductApiController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _response = new ResponseDto();
        }

        [HttpGet]        
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessaages = new List<string>() { ex.ToString() };
                throw;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                _response.Result = productDto;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessaages = new List<string>() { ex.ToString() };
                throw;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody]ProductDto productDto)
        {
            try
            {
                ProductDto p = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = p;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessaages = new List<string>() { ex.ToString() };
                throw;
            }
            return _response;
        }
        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto p = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = p;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessaages = new List<string>() { ex.ToString() };
                throw;
            }
            return _response;
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                bool success= await _productRepository.DeleteProduct(id);
                _response.Result = success;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessaages = new List<string>() { ex.ToString() };
                throw;
            }
            return _response;
        }
    }
}
