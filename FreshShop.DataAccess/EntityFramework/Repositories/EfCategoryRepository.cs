using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshShop.DataAccess.AbstractStructure;
using FreshShop.DataAccess.EntityFramework.Context;
using FreshShop.Model.Domain;
using InfraStructure.DataAccess.EntityFramework;

namespace FreshShop.DataAccess.EntityFramework.Repositories
{
    public class EfCategoryRepository :
        EfBaseRepository<Category, FreshShopDbContext>, ICategoryRepository
    {
    }
}
