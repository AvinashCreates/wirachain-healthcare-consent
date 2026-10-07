namespace wirachain_backend.Shared.Extensions.Exceptions;

public class NotFoundException : Exception
{
    private short CodeError;
    public NotFoundException(string? message, short codeError) : base(message)
    {
        CodeError = codeError;
    }
}