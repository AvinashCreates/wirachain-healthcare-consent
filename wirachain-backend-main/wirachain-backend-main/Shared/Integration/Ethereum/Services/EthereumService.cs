using Microsoft.Extensions.Options;
using Nethereum.Contracts;
using Nethereum.Web3;
using wirachain_backend.Shared.Domain.Services;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Service;
using wirachain_backend.Shared.Settings;

namespace wirachain_backend.Shared.Services;

public class EthereumService : IEthereumService
{
    
    private readonly HttpClient _httpClient;
    private readonly EthereumSettings _settings;
    
    public EthereumService(IOptions<EthereumSettings> settings, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        _settings = settings.Value;
    }

    public async Task<Contract> GetContractByName(string contractName)
    {
        if (!_settings.Contracts.TryGetValue(contractName, out var contractSettings))
        {
            throw new InvalidOperationException($"Contract address {contractName} not found");
        }
        var abiUrl = $"{_settings.AbiDispatcherUrl}/abi/{contractSettings.Path}";
        Console.WriteLine($"abiUrl: {abiUrl}");
        var abi = await _httpClient.GetStringAsync(abiUrl);

        var web3 = new Web3(_settings.RpcUrl);
        return web3.Eth.GetContract(abi, contractSettings.Address);
    }
}