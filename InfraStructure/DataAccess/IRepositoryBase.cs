using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace InfraStructure.DataAccess
{
    public interface IRepositoryBase<TEntity>
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(int id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        int Delete(TEntity entity);
        void Delete(int id);
    }
}
