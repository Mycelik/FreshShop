using FreshShop.DataAccess.AbstractStructure;
using FreshShop.DataAccess.EntityFramework.Context;
using FreshShop.Model.Domain;
using InfraStructure.DataAccess.EntityFramework;

namespace FreshShop.DataAccess.EntityFramework.Repositories
{
    public class EfCustomerRepository :
        EfBaseRepository<Customer, FreshShopDbContext>, ICustomerRepository
    {
    }
}
