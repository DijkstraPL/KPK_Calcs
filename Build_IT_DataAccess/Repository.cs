using Build_IT_DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Properties
        
        protected readonly DbContext Context;

        #endregion // Properties

        #region Constructors
        
        public Repository(DbContext context)
        {
            Context = context;
        }

        #endregion // Constructors

        #region Public_Methods
        
        public virtual Task<TEntity> GetAsync(long id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => { return Context.Set<TEntity>().ToListAsync(); });
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => { return Context.Set<TEntity>().Where(predicate); });
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        #endregion // Public_Methods
    }
}
