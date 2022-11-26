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
    public class ProductPhotoBs:IProductPhotoBs
    {
        IProductPhotoRepository _repo;
        public ProductPhotoBs(IProductPhotoRepository repo)
        {
            _repo = repo;
        }

        

        public void Delete(int id)
        {
            _repo.Delete(GetById(id));
        }

        public List<ProductPhoto> GetAll(Expression<Func<ProductPhoto, bool>> filter = null)
        {
            return _repo.GetAll(filter);
        }

        public List<ProductPhoto> GetAllActive(Expression<Func<ProductPhoto, bool>> filter = null)
        {
            return _repo.GetAll(filter).Where(x => x.IsActive.Value).ToList();
        }


        public ProductPhoto GetById(int id)
        {
            return _repo.GetById(id);
        }


        public ProductPhoto Insert(ProductPhoto productPhoto)
        {
            return  _repo.Insert(productPhoto);
        }



        public ProductPhoto Update(ProductPhoto productPhoto)
        {
            return _repo.Update(productPhoto);
        }
        public int Delete(ProductPhoto productPhoto)
        {
            return _repo.Delete(productPhoto);
        }

        public ProductPhoto Get(Expression<Func<ProductPhoto, bool>> filter)
        {
            return _repo.Get(filter);
        }
    }
}
