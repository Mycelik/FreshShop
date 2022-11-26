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
    public class CategoryBs:ICategoryBs
    {
        ICategoryRepository _repo;
        public CategoryBs(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public int Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _repo.Get(filter);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _repo.GetAll(filter);
        }

        public List<Category> GetAllActive(Expression<Func<Category, bool>> filter = null)
        {
            return _repo.GetAll(filter).Where(x => x.IsActive.Value).ToList();
        }

        public List<Category> GetAllActiveMainCategories()
        {
            return GetAllActive(x => x.TopCategoryId == null).ToList();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetByMainCategoryId(int topCategoryId)
        {
            return GetAllActive(x => x.TopCategoryId == topCategoryId).ToList();
        }

        public Category Insert(Category category)
        {
            return _repo.Insert(category);
        }



        public Category Update(Category category)
        {
            return _repo.Update(category);
        }
    }
}
