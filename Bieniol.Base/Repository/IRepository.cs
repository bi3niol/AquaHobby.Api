using Bieniol.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bieniol.Base.Repository
{
    /// <summary>
    /// Generic Repository interfce
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <typeparam name="TKey">type of entity id</typeparam>
    public interface IRepository<TEntity,TKey> where TEntity: BaseEntity<TKey>
    {
        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);
        /// <summary>
        /// remove given entity
        /// </summary>
        /// <param name="entity">the entity</param>
        void Remove(TEntity entity);
        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity">the entity</param>
        void Update(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>found entity</returns>
        TEntity GetEntity(TKey id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate">filter predicate</param>
        /// <returns>returns entities matched to given predicate</returns>
        IEnumerable<TEntity> GetEntityByFilter(Func<TEntity, bool> predicate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression">filter predicate</param>
        /// <returns>returns entities matched to given expression</returns>
        IQueryable<TEntity> GetEntityByExpression(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// 
        /// </summary>
        /// <returns>retrns all entities</returns>
        IQueryable<TEntity> GetAll();
    }
}
