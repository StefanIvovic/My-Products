using System.Collections.Generic;
using System.Linq;
using MyProducts.BusinessEntities;
using MyProducts.DAL;
using MyProducts.DAL.UnitOfWork;

namespace MyProducts.BusinessServices
{
    public class ProductServices : IProductServices
    {
        private UnitOfWork _unitOfWork;

        public ProductServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateProduct(ProductEntity productEntity)
        {
            var productDb = AutoMapper.Mapper.Map<ProductEntity, Product>(productEntity);
            _unitOfWork.ProductRepository.Insert(productDb);
            _unitOfWork.Save();
        }

        public IEnumerable<ProductEntity> GetAllProducts()
        {
            var productDb = _unitOfWork.ProductRepository.GetAll().ToList();
            var productEntity = AutoMapper.Mapper.Map<List<Product>, List<ProductEntity>>(productDb);
            return productEntity;
        }
    }
}
