using System.Web.Http;
using Unity;
using Unity.WebApi;
using SOTI.SEARCH_PRODUCT;
using SOTI.DAL.DEMO.SEARCH;
using SOTI.DAL.DEMO.SEARCH.Interface;

namespace SOTI.SEARCH_PRODUCT
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ISearchProductByCategoryId, SearchProductByCategory>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}