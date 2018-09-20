using MyProducts.BusinessEntities;
using MyProducts.DAL;
using MyProducts.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProducts.BusinessServices
{
    public  interface ISupplierServices
    {
        void CreateSupplier(SupplierEntity supplierEntity);
    }

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
        }
    }
}
