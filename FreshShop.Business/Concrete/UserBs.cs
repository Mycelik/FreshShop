using FreshShop.Business.AbstractStructure;
using FreshShop.DataAccess.AbstractStructure;
using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace FreshShop.Business.Concrete
{
    public class UserBs:IUserBs
    {
        IUserRepository _repo;
        
        public UserBs(IUserRepository repo)
        {
            _repo = repo;
        }

        public int  Delete(User user)
        {
            return _repo.Delete(user);
        }

        public void Delete(int id)
        {
            _repo.Delete(GetById(id));
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _repo.GetAll(filter);
        }

        public List<User> GetAllActive(Expression<Func<User, bool>> filter = null)
        {
            return _repo.GetAll(filter).Where(x => x.IsActive.Value).ToList();
        }

        public User LogIn(string email, string password)
        {
            return _repo.Get(x => x.Email == email && x.Password == password);
        }
        public User GetById(int id)
        {
            return _repo.GetById(id);
        }

        public User GetByUserName()
        {
            throw new NotImplementedException();
        }

        public User Insert(User user)
        {
           return _repo.Insert(user);
        }

        

        public User Update(User user)
        {
            return _repo.Update(user);
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return _repo.Get(filter);
        }
    }
}
