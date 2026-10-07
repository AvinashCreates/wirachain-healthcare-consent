namespace wirachain_backend.Shared.Integration.Ethereum.Domain.Models;

public class SmartContract
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Abi { get; set; }
    public string Bytecode { get; set; }
    public string Deployed_Bytecode { get; set; }
    public DateTime Created_At { get; set; }
}