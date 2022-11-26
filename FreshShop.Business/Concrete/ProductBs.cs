using FreshShop.Business.AbstractStructure;
using FreshShop.DataAccess.AbstractStructure;
using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Business.Concrete
{
    public class ProductBs:IProductBs
    {
        IProductRepository _repo;
        public ProductBs(IProductRepository repo)
        {
            _repo = repo;
        }

        

        public void Delete(int id)
        {
            _repo.Delete(GetById(id));
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _repo.GetAll(filter);
        }

        public List<Product> GetAllActive(Expression<Func<Product, bool>> filter = null)
        {
            return _repo.GetAll(filter).Where(x => x.IsActive.Value).ToList();
        }


        public Product GetById(int id)
        {
            return _repo.GetById(id);
        }


        public Product Insert(Product product)
        {
            return _repo.Insert(product);
        }


        public Product Update(Product product)
        {
            return _repo.Update(product);
        }
        public int Delete(Product product)
        {
           return _repo.Delete(product);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _repo.Get(filter);
        }
    }
}
