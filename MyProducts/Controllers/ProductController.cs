using MyProducts.BusinessEntities;
using MyProducts.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProducts.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IManufacturerServices _manufacturerServices;
        private readonly ISupplierServices _supplierServices;

        public ProductController(
            IProductServices productServices,
            ICategoryServices categoryServices,
            IManufacturerServices manufacturerServices,
            ISupplierServices supplierServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _manufacturerServices = manufacturerServices;
            _supplierServices = supplierServices;
        }


        // GET: Product
        public ActionResult Index()
        {
            var products = _productServices.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //TODO finish adding select lists for the rest of models required by product
            ViewBag.CategoryList = new SelectList(_categoryServices.GetAllCategories(), "Id", "Name");
            ViewBag.ManufacList = new SelectList(_manufacturerServices.GetAllManufacturers(), "Id", "Name");
            ViewBag.SupplierList = new SelectList(_supplierServices.GetAllSuppliers(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductEntity productEntity)
        {
            if (ModelState.IsValid)
            {
                _productServices.CreateProduct(productEntity);
                return RedirectToAction("Index", "Home");
            }

            return View(productEntity);
        }
        public ActionResult Edit(int id)
        {
            var product = _productServices.GetProductById(id);
            if (product == null)
                return HttpNotFound();
            ViewBag.CategoryList = new SelectList(_categoryServices.GetAllCategories(), "Id", "Name");
            ViewBag.ManufacList = new SelectList(_manufacturerServices.GetAllManufacturers(), "Id", "Name");
            ViewBag.SupplierList = new SelectList(_supplierServices.GetAllSuppliers(), "Id", "Name");
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductEntity productEntity)
        {
            if (ModelState.IsValid)
            {
                _productServices.UpdateProduct(productEntity);
                return RedirectToAction("Index");
            }
            return View(productEntity);

        }


    }
}