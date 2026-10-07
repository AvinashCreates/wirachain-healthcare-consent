namespace wirachain_backend.Shared.Integration.Ethereum.Domain.Events;

public interface IEventEmitter
{
    Task EmitEventAsync(int signerIndex, object request);
}

public interface IEventEmitter<in T> : IEventEmitter
{
    Task EmitEventAsync(int signerIndex, T request);
}