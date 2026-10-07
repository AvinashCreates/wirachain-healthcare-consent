using Microsoft.EntityFrameworkCore.Storage;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Persistence.Context;

namespace wirachain_backend.Shared.Persistence.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    
    public async Task BeginTransactionAsync()
    {
        _transaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await context.SaveChangesAsync();
            await _transaction!.CommitAsync();
        }
        catch
        {
            await _transaction!.RollbackAsync();
            throw;
        }
        finally
        {
            await _transaction!.DisposeAsync();
        }
    }

    public async Task RollbackTrasactionAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync();
            await _transaction!.DisposeAsync();
        }
    }

    public async Task CommitAsync()
    {
        await _transaction!.CommitAsync();
    }
}