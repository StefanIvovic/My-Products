using System.Collections.Generic;
using System.Linq;
using MyProducts.BusinessEntities;
using MyProducts.DAL;
using MyProducts.DAL.UnitOfWork;

namespace MyProducts.BusinessServices
{
    public class CategoryServices : ICategoryServices
    {
        private UnitOfWork _unitOfWork;

        public CategoryServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void CreateCategory(CategoryEntity categoryEntity)
        {
            var categoryDb = AutoMapper.Mapper.Map<CategoryEntity, Category>(categoryEntity);
            _unitOfWork.CategoryRepository.Insert(categoryDb);
            _unitOfWork.Save();
        }

        public IEnumerable<CategoryEntity> GetAllCategories()
        {
            var catDb = _unitOfWork.CategoryRepository.GetAll().ToList();
            if (catDb == null)
                return null;

            var catEntity = AutoMapper.Mapper.Map<List<Category>, List<CategoryEntity>>(catDb);
            return catEntity;
        }
    }
}
