namespace wirachain_backend.Shared.Domain.Services.Communication;

public class BaseResponse<TEntity>
{
    public TEntity? Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }

    public BaseResponse(TEntity? entity)
    {
        Data = entity;
        Success = true;
        Message = string.Empty;
    }

    public BaseResponse(string message)
    {
        Message = message;
        Success = false;
        Data = default;
    }
}