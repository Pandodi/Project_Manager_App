using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task RollbackTransactionAsync();
        Task<int> SaveAsync();
        void Update(TEntity entity);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
        
        //test
        Task<IEnumerable<TEntity>> GetAllDetailedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? expression = null);
        Task<TEntity?> GetDetailAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeExpression = null);
    }
}