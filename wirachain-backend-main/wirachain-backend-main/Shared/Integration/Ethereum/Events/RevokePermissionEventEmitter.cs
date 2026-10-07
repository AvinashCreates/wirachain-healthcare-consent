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

public class RevokePermissionEventEmitter : IEventEmitter<PermissionRequest>
{
    private readonly EthereumSettings _settings;
    private readonly HttpClient _httpClient;
    private readonly IWalletManager _walletManager;

    public RevokePermissionEventEmitter(IOptions<EthereumSettings> options, HttpClient httpClient,
        IWalletManager walletManager)
    {
        _settings = options.Value;
        _httpClient = httpClient;
        _walletManager = walletManager;
    }

    public async Task EmitEventAsync(int signerIndex, PermissionRequest request)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{_settings.SmartContractManagerUrl}/contract/1");
        response.EnsureSuccessStatusCode();

        var account = new Account("0x8fcfc18a4bb9212fd9c0811c96f58c4200420fd836f8af03066df130b2baee05");
        var web3 = new Web3(account, _settings.RpcUrl);

        var responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseString);
        var contractData = JsonSerializer.Deserialize<SmartContract>(responseString,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        var contract = web3.Eth.GetContract(contractData?.Abi, contractData?.Address);
        Console.WriteLine($"Contract Address: {contractData?.Address}");
        Console.WriteLine($"Contract ABI: {contractData?.Abi}");
        // Get Function from Contract
        Function function = contract.GetFunction("revokePatientPermission");

        // Transform GUID to String
        string patientGuidString = request.PatientId.ToString();

        // Estimate Gas
        var gasEstimate = await function.EstimateGasAsync(
            from: account.Address, gas: null, value: null,
            functionInput: [patientGuidString, request.ClinicId]);

        // Send transaction
        var txHash = await function.SendTransactionAsync(from: account.Address, gas: gasEstimate, value: null,
            functionInput: [patientGuidString, request.ClinicId]);

        Console.WriteLine($"Sent Transaction: {txHash}");
    }

    public async Task EmitEventAsync(int signerIndex, object request) =>
        await EmitEventAsync(signerIndex, (PermissionRequest)request);
}