using MyProducts.BusinessServices;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MyProducts
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICategoryServices, CategoryServices>();
            container.RegisterType<IManufacturerServices, ManufecturerServices>();
            container.RegisterType<ISupplierServices, SupplierServices>();
            container.RegisterType<IProductServices, ProductServices>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}