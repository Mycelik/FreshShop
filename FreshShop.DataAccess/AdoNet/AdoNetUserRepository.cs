using FreshShop.DataAccess.AbstractStructure;
using FreshShop.Model.Domain;
using InfraStructure.DataAccess.AdoNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.DataAccess.AdoNet
{
    public class AdoNetUserRepository :
        AdoBaseRepository<User>, IUserRepository
    {
        public User GetByUserName()
        {
            throw new NotImplementedException();
        }
    }
}
