using FreshShop.Business.AbstractStructure;
using FreshShop.Business.Concrete;
using FreshShop.DataAccess.AbstractStructure;
using FreshShop.DataAccess.EntityFramework.Repositories;
using Ninject.Modules;

namespace FreshShop.Business.DependencyResolvers.Ninject
{
    public class NinjectBusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserBs>().To<UserBs>();
            Bind<IUserRepository>().To<EfUserRepository>();

            Bind<IRoleBs>().To<RoleBs>();
            Bind<IRoleRepository>().To<EfRoleRepository>();

            Bind<ICategoryBs>().To<CategoryBs>();
            Bind<ICategoryRepository>().To<EfCategoryRepository>();

            Bind<ICustomerBs>().To<CustomerBs>();
            Bind<ICustomerRepository>().To<EfCustomerRepository>();

            Bind<IProductBs>().To<ProductBs>();
            Bind<IProductRepository>().To<EfProductRepository>();

            Bind<IProductPhotoBs>().To<ProductPhotoBs>();
            Bind<IProductPhotoRepository>().To<EfProductPhotoRepository>();

            Bind<IProductCommentBs>().To<ProductCommentBs>();
            Bind<IProductCommentRepository>().To<EfProductCommentRepository>();
        }
    }
}
