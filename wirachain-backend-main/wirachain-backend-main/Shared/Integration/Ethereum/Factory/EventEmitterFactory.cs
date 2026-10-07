using wirachain_backend.Shared.Integration.Ethereum.Domain.Events;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Factory;
using wirachain_backend.Shared.Integration.Ethereum.Events;

namespace wirachain_backend.Shared.Integration.Ethereum.Factory;

public class EventEmitterFactory(IServiceProvider serviceProvider) : IEventEmitterFactory
{
    public IEventEmitter<T> Create<T>(string eventName)
    {
        return eventName switch
        {
            "GrantPermission" =>
                serviceProvider.GetRequiredService<GrantPermissionEventEmitter>() as IEventEmitter<T> ??
                throw new InvalidCastException(
                    $"Emitter for {eventName} is not of type IEventEmitter<{typeof(T).Name}>"),
            "RevokePermission" =>
                serviceProvider.GetRequiredService<RevokePermissionEventEmitter>() as IEventEmitter<T> ??
                throw new InvalidCastException(
                    $"Emmiter for {eventName} is not of type IEventEmitter<{typeof(T).Name}>"),
            _ => throw new ArgumentException($"Event {eventName} not found.")
        };
    }
}