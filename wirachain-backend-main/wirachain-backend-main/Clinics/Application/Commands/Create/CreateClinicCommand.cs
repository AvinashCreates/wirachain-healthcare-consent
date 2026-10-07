namespace wirachain_backend.Clinics.Application.Commands.Create;

public class CreateClinicCommand
{
    public string Ruc { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid AdministratorId { get; set; }
    public IList<long> MedicalTestIds { get; set; } = new List<long>();
}