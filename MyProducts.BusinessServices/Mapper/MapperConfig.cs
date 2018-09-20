using MyProducts.BusinessEntities;
using MyProducts.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProducts.BusinessServices.Mapper
{
    public static class MapperConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(cfg => {
                //source, destination            
                cfg.CreateMap<Category, CategoryEntity>();
                cfg.CreateMap<CategoryEntity, Category>();

                cfg.CreateMap<Manufacturer, ManufacturerEntity>();
                cfg.CreateMap<ManufacturerEntity, Manufacturer>();

                cfg.CreateMap<Product, ProductEntity>();
                cfg.CreateMap<ProductEntity, Product>();

                cfg.CreateMap<Supplier, SupplierEntity>();
                cfg.CreateMap<SupplierEntity, Supplier>();

            });
        }
    }
}
