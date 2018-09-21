using MyProducts.BusinessEntities;
using MyProducts.DAL;
using MyProducts.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<ManufacturerEntity> GetAllManufacturers()
        {
            var manufacturersDb = _unitOfWork.ManufacturerRepository.GetAll().ToList();
            var manufacturersEntity = AutoMapper.Mapper.Map<List<Manufacturer>, List<ManufacturerEntity>>(manufacturersDb);
            return manufacturersEntity;
        }
    }
}
