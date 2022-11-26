using FreshShop.Business.AbstractStructure;
using FreshShop.DataAccess.AbstractStructure;
using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Business.Concrete
{
    public class RoleBs : IRoleBs
    {
        IRoleRepository _repo;
        public RoleBs(IRoleRepository repo)
        {
            _repo = repo;
        }

        public int Delete(Role role)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Role Get(Expression<Func<Role, bool>> filter)
        {
            return _repo.Get(filter);
        }

        public List<Role> GetAll(Expression<Func<Role, bool>> filter = null)
        {
            return _repo.GetAll(filter);
        }

        public List<Role> GetAllActive(Expression<Func<Role, bool>> filter = null)
        {
            return _repo.GetAll(filter).Where(x => x.IsActive.Value).ToList();
        }

        public Role GetById(int id)
        {
            return GetById(id);
        }


        public Role Insert(Role role)
        {

            return _repo.Insert(role);
        }



        public Role Update(Role role)
        {
            return _repo.Update(role);
        }
    }
}
