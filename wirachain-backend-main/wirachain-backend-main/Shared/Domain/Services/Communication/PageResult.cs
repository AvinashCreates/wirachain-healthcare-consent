namespace wirachain_backend.Shared.Domain.Services.Communication;

public class PageResult<TEntity>
{
    public int Count { get; set; }
    public IEnumerable<TEntity> Results { get; set; } = new List<TEntity>();
}