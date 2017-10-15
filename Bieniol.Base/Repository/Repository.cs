using Bieniol.Base.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
        public TEntity Add(TEntity entity)
        {
            return dbSet.Add(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet.Where(e => true);
        }

        public TEntity GetEntity(TKey id)
        {
            return dbSet.FirstOrDefault(e => e.Id.ToString()==id.ToString());
        }

        public IQueryable<TEntity> GetEntityByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetEntityByFilterAsync(Func<TEntity, bool> predicate)
        {
            var list = await dbSet.ToListAsync();
            return list.Where(predicate);
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
            entity = dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
