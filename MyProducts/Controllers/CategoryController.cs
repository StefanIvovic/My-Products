using MyProducts.BusinessEntities;
using MyProducts.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProducts.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryEntity categoryEntity)
        {
            if (ModelState.IsValid)
            {
                _categoryServices.CreateCategory(categoryEntity);
                return RedirectToAction("Index", "Home");
            }

            return View(categoryEntity);
        }

    }
}