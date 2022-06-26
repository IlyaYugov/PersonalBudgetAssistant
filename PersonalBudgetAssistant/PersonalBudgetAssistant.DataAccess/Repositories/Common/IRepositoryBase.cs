using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PersonalBudgetAssistant.DataAccess.Repositories.Common
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> FindByIdAsync(object id);

        Task<List<TEntity>> GetAllAsync();

        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entity);

        Task Remove(object id);

        void Remove(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}