using wirachain_backend.Shared.Integration.Ethereum.Domain.Events;

namespace wirachain_backend.Shared.Integration.Ethereum.Domain.Factory;

public interface IEventEmitterFactory
{
    IEventEmitter<T> Create<T>(string eventName); // Adding template to the method, not to all the class.
}