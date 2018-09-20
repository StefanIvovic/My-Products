using MyProducts.BusinessEntities;
using MyProducts.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProducts.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerServices _manufacturerServices;

        public ManufacturerController(IManufacturerServices manufacturerServices)
        {
            _manufacturerServices = manufacturerServices;
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManufacturerEntity manufacturerEntity)
        {
            if (ModelState.IsValid)
            {
                _manufacturerServices.CreateManufacturer(manufacturerEntity);
                return RedirectToAction("Index", "Home");
            }

            return View(manufacturerEntity);
        }

        //// GET: Manufacturer
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}