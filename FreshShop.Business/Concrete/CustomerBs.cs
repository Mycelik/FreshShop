
using FreshShop.Business.AbstractStructure;
using FreshShop.DataAccess.AbstractStructure;
using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Business.Concrete
{
    public class CustomerBs:ICustomerBs
    {
        ICustomerRepository _repo;
        public CustomerBs(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public int Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            return _repo.Get(filter);
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return _repo.GetAll(filter);
        }

        public List<Customer> GetAllActive(Expression<Func<Customer, bool>> filter = null)
        {
            return _repo.GetAll(filter).Where(x => x.IsActive.Value).ToList();
        }


        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }


        public Customer Insert(Customer customer)
        {
            return _repo.Insert(customer);
        }



        public Customer Update(Customer customer)
        {
            return _repo.Update(customer);
        }
    }
}
