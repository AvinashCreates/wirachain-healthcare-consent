namespace wirachain_backend.Shared.Integration.Ethereum.Domain.Events;

public interface IEventEmitter
{
    Task<string> EmitEventAsync(int signerIndex, object request);
}

public interface IEventEmitter<in T> : IEventEmitter
{
    Task<string> EmitEventAsync(int signerIndex, T request);
}