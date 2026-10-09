using Microsoft.Extensions.Options;
using Nethereum.Web3.Accounts;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Managers;
using wirachain_backend.Shared.Settings;

namespace wirachain_backend.Shared.Integration.Ethereum.Managers;

public class WalletManager : IWalletManager
{
    private readonly IList<Account> _accounts = new List<Account>();

    public WalletManager(IOptions<EthereumSettings> options)
    {
        var allKeys = options.Value.AllPrivateKeys;
        foreach (var key in allKeys)
            _accounts.Add(new Account(key));
    }

    public Task<Account> GetAccountAsync(string address)
    {
        var account = _accounts.FirstOrDefault(x => x.Address.Equals(address, StringComparison.OrdinalIgnoreCase));
        if (account is null)
            throw new KeyNotFoundException($"Account with address {address} not found");

        return Task.FromResult(account);
    }

    public Account GetAccountByAddress(string address)
    {
        return _accounts.FirstOrDefault(x => x.Address.Equals(address, StringComparison.OrdinalIgnoreCase)) ??
               throw new KeyNotFoundException($"Account with address {address} not found");
    }
    
    public Account GetAccountByIndex(int index)
    {
        return _accounts[index];
    }

    public IEnumerable<string> GetAllAddresses()
    {
        return _accounts.Select(x => x.Address);
    }

    public Task<int> CountAccountsAsync()
    {
        return Task.FromResult(_accounts.Count);
    }

    public int CountAccounts()
    {
       return _accounts.Count;
    }
}