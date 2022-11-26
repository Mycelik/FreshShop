using InfraStructure.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.DataAccess.EntityFramework
{
    public class EfBaseRepository<TEntity,TContext> 
        :IRepositoryBase<TEntity>
        where TEntity : BaseDomain,new()
        where TContext : DbContext,new()
    {
        TContext ctx = new TContext();

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
                return ctx.Set<TEntity>().Where(filter).ToList();

            return ctx.Set<TEntity>().ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return ctx.Set<TEntity>().SingleOrDefault(filter);
        }

        public TEntity GetById(int id)
        {
            return ctx.Set<TEntity>().SingleOrDefault(x => x.Id == id);
        }
        public TEntity Insert(TEntity entity)
        {
            DbEntityEntry<TEntity> insertedEntity = ctx.Entry(entity);
            insertedEntity.State = EntityState.Added;
            ctx.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            DbEntityEntry<TEntity> updateEntity = ctx.Entry(entity);
            updateEntity.State = EntityState.Modified;

            ctx.SaveChanges();
            return entity;

        }

        public int Delete(TEntity entity)
        {
            DbEntityEntry<TEntity> deletedEntity = ctx.Entry(entity);
            deletedEntity.State = EntityState.Deleted;

          

           return ctx.SaveChanges();

        }

        public void Delete(int id)
        {
            
            Delete(GetById(id));
        }
    }
}
