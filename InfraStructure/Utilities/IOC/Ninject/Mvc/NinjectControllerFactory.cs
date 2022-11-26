using Ninject;
using Ninject.Modules;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace InfraStructure.Utilities.IOC.Ninject.Mvc
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _kernel;
        public NinjectControllerFactory(INinjectModule module)
        {
            _kernel = new StandardKernel(module);
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)_kernel.Get(controllerType);
        }
    }
}
