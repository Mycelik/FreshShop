using FreshShop.DataAccess.AbstractStructure;
using FreshShop.DataAccess.EntityFramework.Context;
using FreshShop.Model.Domain;
using InfraStructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.DataAccess.EntityFramework.Repositories
{
    public class EfUserRepository : 
        EfBaseRepository<User, FreshShopDbContext>, IUserRepository
    {
        public User GetByUserName()
        {
            throw new NotImplementedException();
        }
    }
}
