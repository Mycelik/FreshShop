using FluentValidation.Mvc;
using FreshShop.Business.DependencyResolvers.Ninject;
using InfraStructure.Utilities.IOC.Ninject.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FreshShop.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new NinjectBusinessModule()));
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
