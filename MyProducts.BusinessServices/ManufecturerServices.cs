using MyProducts.BusinessEntities;
using MyProducts.DAL;
using MyProducts.DAL.UnitOfWork;
using System;

namespace MyProducts.BusinessServices
{
    public class ManufecturerServices : IManufacturerServices
    {
        private UnitOfWork _unitOfWork;

        public ManufecturerServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateManufacturer(ManufacturerEntity manufacturerEntity)
        {
            var manufacturerDb = AutoMapper.Mapper.Map<ManufacturerEntity, Manufacturer>(manufacturerEntity);
            _unitOfWork.ManufacturerRepository.Insert(manufacturerDb);
            _unitOfWork.Save();
        }
    }
}
