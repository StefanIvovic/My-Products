using System.Collections.Generic;
using System.Linq;
using MyProducts.BusinessEntities;
using MyProducts.DAL;
using MyProducts.DAL.UnitOfWork;

namespace MyProducts.BusinessServices
{
    public class SupplierServices : ISupplierServices
    {
        private UnitOfWork _unitOfWork;

        public SupplierServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateSupplier(SupplierEntity supplierEntity)
        {
            var supplierDb = AutoMapper.Mapper.Map<SupplierEntity, Supplier>(supplierEntity);
            _unitOfWork.SupplierRepository.Insert(supplierDb);
            _unitOfWork.Save();
        }

        public IEnumerable<SupplierEntity> GetAllSuppliers()
        {
            var suppliersDb = _unitOfWork.SupplierRepository.GetAll().ToList();
            var suppliersEntity = AutoMapper.Mapper.Map<List<Supplier>, List<SupplierEntity>>(suppliersDb);
            return suppliersEntity;
        }
    }
}
