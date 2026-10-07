using Nethereum.Contracts;

namespace wirachain_backend.Shared.Integration.Ethereum.Domain.Service;

public interface IEthereumService
{
    Task<Contract> GetContractByName(string contractName);
}