using Business.Interfaces;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;


//Had some minor issues getting the dependency injection completely correct so had ChatGPT do some modifications
public abstract class BaseService<TRepository, TEntity>(TRepository repository) : IBaseService<TEntity> where TRepository : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly TRepository _repository = repository;

    public async Task<bool> CreateAsync(TEntity entity)
    {

        await _repository.BeginTransactionAsync();

        try
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            await _repository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _repository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        await _repository.BeginTransactionAsync();
        try
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
            await _repository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _repository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _repository.GetAsync(expression);
        if (entity == null) return false;

        await _repository.BeginTransactionAsync();
        try
        {
            _repository.Delete(entity);
            await _repository.SaveAsync();
            await _repository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _repository.RollbackTransactionAsync();
            return false;
        }
    }
}
