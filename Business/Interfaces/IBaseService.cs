using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
        Task<bool> UpdateAsync(TEntity entity);
    }
}