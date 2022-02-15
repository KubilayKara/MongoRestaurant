using Microsoft.AspNetCore.Mvc;
using Mongo.Web.Models;
using Mongo.Web.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mongo.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new List<ProductDto>();
            ResponseDto response = await _productService.GetAllProductsAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            //response.Result
            return View(list);
        }
        public async Task<IActionResult> ProductCreate()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            ResponseDto response = await _productService.CreateProductAsync<ResponseDto>(model);
            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(ProductIndex));
            //response.Result
            return View(model);
        }
    }
}
