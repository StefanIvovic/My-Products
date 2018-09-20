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
    }
}
