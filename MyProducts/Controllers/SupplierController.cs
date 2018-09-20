using MyProducts.BusinessEntities;
using MyProducts.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProducts.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierServices _supplierServices;

        public SupplierController(ISupplierServices supplierServices)
        {
            _supplierServices = supplierServices;
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierEntity supplierEntity)
        {
            if (ModelState.IsValid)
            {
                _supplierServices.CreateSupplier(supplierEntity);
                return RedirectToAction("Index", "Home");
            }

            return View(supplierEntity);
        }

        //// GET: Supplier
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}