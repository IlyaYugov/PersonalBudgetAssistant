using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PersonalBudgetAssistant.DataAccess.Repositories.Common
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly BudgetContext Context;

        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(BudgetContext context)
        {
            Context = context;
            _dbSet = Context.Set<TEntity>();
        }

        public virtual Task<TEntity> FindByIdAsync(object id)
        {
            return _dbSet.FindAsync(id);
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return GetByPredicateAsync();
        }

        public virtual Task<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
            return _dbSet.AddAsync(entity);
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entity)
        {
            return _dbSet.AddRangeAsync(entity);
        }

        public virtual async Task Remove(object id)
        {
            var entityToDelete = await FindByIdAsync(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        protected virtual async Task<TEntity> FindByIdAsync(object id, IEnumerable<string> includePaths)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            foreach (var includePath in includePaths)
            {
                await Context.Entry(entity)
                    .Reference(includePath).LoadAsync();
            }

            return entity;
        }

        protected Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate != null
                ? _dbSet.FirstOrDefaultAsync(predicate)
                : _dbSet.FirstOrDefaultAsync();
        }

        protected Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.SingleOrDefaultAsync(predicate);
        }

        protected Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AnyAsync(predicate);
        }

        protected Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.CountAsync(predicate);
        }

        protected Task<List<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate != null
                ? _dbSet.Where(predicate).ToListAsync()
                : _dbSet.ToListAsync();
        }

        protected Task<List<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includePaths)
        {
            var entities = Context.Set<TEntity>().AsQueryable();

            entities = AddIncludes(entities, includePaths);

            var result = predicate != null
                ? entities.Where(predicate).ToListAsync()
                : entities.ToListAsync();

            return result;
        }

        protected IQueryable<TEntity> AddIncludes(IQueryable<TEntity> entities, IEnumerable<string> includePaths)
        {
            // using special overload of include that takes string
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.include?view=efcore-3.1
            return includePaths.Aggregate(entities,
                (current, includePath) => current.Include(includePath));
        }
    }
}