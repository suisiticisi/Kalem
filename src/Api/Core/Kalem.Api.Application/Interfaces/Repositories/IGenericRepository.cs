using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Kalem.Api.Domain.Models;

namespace Kalem.Api.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> AddAsync(TEntity entity);
        IQueryable<TEntity> AsQueryable();
        Task<List<TEntity>> GetAll(bool noTracking = true);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate,
            bool noTracking = true,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
      
        Task<TEntity> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);

        Task<int> DeleteAsync(TEntity entity);
        int Delete(TEntity entity);
        Task<int> DeleteAsync(Guid id);
        int Delete(Guid id);
        bool DeleteRange(Expression<Func<TEntity, bool>> predicate);
        Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);


        Task<int> UpdateAsync(TEntity entity);
        int Update(TEntity entity);

        Task<int> SaveChangeAsync();

        int SaveChange();
    }
}
