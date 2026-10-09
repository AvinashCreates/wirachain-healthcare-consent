using System.Numerics;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using wirachain_backend.Shared.Integration.Ethereum.Application.Requests;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Events;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Managers;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Models;
using wirachain_backend.Shared.Settings;

namespace wirachain_backend.Shared.Integration.Ethereum.Events;

public class GrantPermissionEventEmitter : IEventEmitter<PermissionRequest>
{
    private readonly EthereumSettings _settings;
    private readonly HttpClient _httpClient;
    private readonly IWalletManager _walletManager;

    public GrantPermissionEventEmitter(IOptions<EthereumSettings> options, HttpClient httpClient,
        IWalletManager walletManager)
    {
        _settings = options.Value;
        _httpClient = httpClient;
        _walletManager = walletManager;
    }

    public async Task<string> EmitEventAsync(int signerIndex, PermissionRequest request)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{_settings.SmartContractManagerUrl}/contract/1");
        response.EnsureSuccessStatusCode();

        var account = _walletManager.GetAccountByIndex(signerIndex);
        var web3 = new Web3(account, _settings.RpcUrl);

        var responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseString);
        var contractData = JsonSerializer.Deserialize<SmartContract>(responseString,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (contractData is null || string.IsNullOrWhiteSpace(contractData.Address) || contractData.Abi is null)
        {
            throw new InvalidOperationException("Smart contract metadata is missing or invalid for permission events.");
        }

        var contract = web3.Eth.GetContract(contractData.Abi, contractData.Address);
        Console.WriteLine($"Contract Address: {contractData.Address}");
        Console.WriteLine($"Contract ABI: {contractData.Abi}");

        Function function = contract.GetFunction("grantPatientPermission");
        string patientGuidString = request.PatientId.ToString();

        var gasEstimate = await function.EstimateGasAsync(
            from: account.Address, gas: null, value: null,
            functionInput: [patientGuidString, request.ClinicId]);

        var txHash = await function.SendTransactionAsync(from: account.Address, gas: gasEstimate, value: null,
            functionInput: [patientGuidString, request.ClinicId]);

        Console.WriteLine($"Sent Transaction: {txHash}");
        return txHash;
    }

    public Task<string> EmitEventAsync(int signerIndex, object request) =>
        EmitEventAsync(signerIndex, (PermissionRequest)request);
}