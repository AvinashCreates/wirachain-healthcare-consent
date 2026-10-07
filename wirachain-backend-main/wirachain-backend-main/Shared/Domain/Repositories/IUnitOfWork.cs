namespace wirachain_backend.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTrasactionAsync();
    Task CommitAsync();
    
}