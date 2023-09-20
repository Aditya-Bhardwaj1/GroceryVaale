using Grocery.Soti.Project.DAL;
using Grocery.Soti.Project.DAL.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Grocery.Soti.Project.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
<<<<<<< HEAD
           container.RegisterType<ICategory, CategoriesDetails>();
           container.RegisterType<IProduct, ProductDetails>();

=======
            container.RegisterType<IProduct, ProductService>();
>>>>>>> origin/master
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}