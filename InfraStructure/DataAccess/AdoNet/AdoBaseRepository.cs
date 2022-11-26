using InfraStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.DataAccess.AdoNet
{
    public class AdoBaseRepository<TEntity>
        : IRepositoryBase<TEntity>
        where TEntity : BaseDomain, new()
    {
        public int Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
