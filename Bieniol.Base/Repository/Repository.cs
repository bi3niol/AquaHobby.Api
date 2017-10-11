using Bieniol.Base.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Bieniol.Base.Repository
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected DbContext context;
        protected DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet.Where(e=>true);
        }

        public TEntity GetEntity(TKey id)
        {            
            return dbSet.FirstOrDefault(e=>e.Id.Equals(id));
        }

        public IQueryable<TEntity> GetEntityByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IEnumerable<TEntity> GetEntityByFilter(Func<TEntity, bool> predicate)
        {
            return dbSet.ToList().Where(predicate);
        }

        public void Remove(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
