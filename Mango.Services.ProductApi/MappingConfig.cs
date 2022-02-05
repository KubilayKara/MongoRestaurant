using AutoMapper;
using Mango.Services.ProductApi.Modals;
using Mango.Services.ProductsApi.DbContexts.Modals;

namespace Mango.Services.ProductApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
              {
                  config.CreateMap<ProductDto, Product>();
                  config.CreateMap<Product, ProductDto>();
               });
            return mappingConfig;

        }
    }
}
