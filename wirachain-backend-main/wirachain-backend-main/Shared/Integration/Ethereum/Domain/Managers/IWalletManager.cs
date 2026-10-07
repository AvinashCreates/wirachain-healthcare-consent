using Nethereum.Web3.Accounts;

namespace wirachain_backend.Shared.Integration.Ethereum.Domain.Managers;

public interface IWalletManager
{
    Task<Account> GetAccountAsync(string address);
    Account? GetAccountByAddress(string address);
    Account GetAccountByIndex(int index);
    public IEnumerable<string> GetAllAddresses();
    Task<int> CountAccountsAsync();
    int CountAccounts();
}