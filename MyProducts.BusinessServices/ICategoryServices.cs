﻿using MyProducts.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProducts.BusinessServices
{
    public interface ICategoryServices
    {
        IEnumerable<CategoryEntity> GetAllCategories();
        void CreateCategory(CategoryEntity categoryEntity);
    }
}
