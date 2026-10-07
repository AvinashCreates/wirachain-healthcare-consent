using System.Linq.Expressions;

namespace wirachain_backend.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity, in TKey>
{
    Task<TEntity?> FindAsync(TKey id);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);
}