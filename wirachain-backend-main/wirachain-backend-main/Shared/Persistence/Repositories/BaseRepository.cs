using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Persistence.Context;

namespace wirachain_backend.Shared.Persistence.Repositories;

public class BaseRepository<TEntity, TKey>(AppDbContext context) : IBaseRepository<TEntity, TKey>
    where TEntity : class
{
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public virtual async Task<TEntity?> FindAsync(TKey id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public virtual void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public virtual void Remove(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AnyAsync(predicate);
    }
}