using AutoMapper;
using Mango.Services.ProductApi.Modals;
using Mango.Services.ProductsApi.DbContexts;
using Mango.Services.ProductsApi.DbContexts.Modals;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductApi.Rapository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            if (product.ProductId > 0)
            {
                //Product result = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

                //if (result == null)
                //    return null;
                //result.Name = product.Name;
                //result.Price = product.Price;
                //result.ImageUrl = product.ImageUrl;
                //result.Description = product.Description;

                _db.Update(product);
                
            }
            else
            {
                await _db.AddAsync(product);
                
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<bool> DeleteProduct(int productId)
        {

            try
            {
                var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

                if (product == null)
                    return false;
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            IEnumerable<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
