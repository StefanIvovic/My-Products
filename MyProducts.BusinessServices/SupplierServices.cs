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
    }
}
