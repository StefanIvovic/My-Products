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

        public ProductEntity GetProductById(int id)
        {
            var productdb = _unitOfWork.ProductRepository.GetById(id);
            if (productdb == null)
                return null;

            var productEntity = AutoMapper.Mapper.Map<Product, ProductEntity>(productdb);
            return productEntity;
        }

        public void UpdateProduct(ProductEntity productEntity)
        {
            var productDb = _unitOfWork.ProductRepository.GetById(productEntity.Id);
            if(productDb != null)
            {
                AutoMapper.Mapper.Map(productEntity, productDb);
                productDb.Manufacturer = _unitOfWork.ManufacturerRepository.GetById(productDb.Manufacturer.Id);
                productDb.Supplier = _unitOfWork.SupplierRepository.GetById(productDb.Supplier.Id);
                productDb.Category = _unitOfWork.CategoryRepository.GetById(productDb.Category.Id);
                _unitOfWork.ProductRepository.Update(productDb);
                _unitOfWork.Save();
            }
        }
    }
}
