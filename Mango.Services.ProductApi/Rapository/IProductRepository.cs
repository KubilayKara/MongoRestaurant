using AutoMapper;
using Mango.Services.ProductApi.Modals;
using Mango.Services.ProductsApi.DbContexts;
using Mango.Services.ProductsApi.DbContexts.Modals;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteProduct(int productId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x=> x.ProductId==productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            IEnumerable<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
