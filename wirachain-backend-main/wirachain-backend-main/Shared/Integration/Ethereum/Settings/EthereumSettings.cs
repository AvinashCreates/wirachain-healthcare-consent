namespace wirachain_backend.Shared.Settings;

public class EthereumSettings
{
    public class ContractSettings
    {
        public string Path { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public List<string> PrivateKeys { get; set; } = new();
    public string RpcUrl { get; set; } = string.Empty;
    public string AbiDispatcherUrl { get; set; } = string.Empty;
    public string SmartContractManagerUrl { get; set; } = string.Empty;
    public Dictionary<string, ContractSettings> Contracts { get; set; } = new();
    public List<string> AllPrivateKeys => MergedPrivateKeys();

    // Merge public 
    private List<string> MergedPrivateKeys()
    {
        var envRaw = Environment.GetEnvironmentVariable("SIGNER_KEYS");
        var envKeys = string.IsNullOrEmpty(envRaw)
            ? new List<string>()
            : envRaw.Split(',', StringSplitOptions.TrimEntries).ToList();
        return PrivateKeys.Concat(envKeys).Distinct().ToList();
    }
}