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
    public class ProductCommentBs : IProductCommentBs
    {
        IProductCommentRepository _repo;
        public ProductCommentBs(IProductCommentRepository repo)
        {
            _repo = repo;
        }

        public int Delete(ProductComment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProductComment Get(Expression<Func<ProductComment, bool>> filter)
        {
            return _repo.Get(filter);
        }

        public List<ProductComment> GetAll(Expression<Func<ProductComment, bool>> filter = null)
        {
            return _repo.GetAll(filter);
        }

        public List<ProductComment> GetAllActive(Expression<Func<ProductComment, bool>> filter = null)
        {
            return _repo.GetAll(filter).Where(x => x.IsActive.Value).ToList();
        }

      
        public ProductComment GetById(int id)
        {
            throw new NotImplementedException();
        }

      
        public ProductComment Insert(ProductComment productComment)
        {
            return _repo.Insert(productComment);
        }

        public ProductComment Update(ProductComment productComment)
        {
            return _repo.Update(productComment);
        }
    }
}
