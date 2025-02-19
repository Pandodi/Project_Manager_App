using System.Linq.Expressions;

namespace Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task RollbackTransactionAsync();
        Task<int> SaveAsync();
        void Update(TEntity entity);
    }
}