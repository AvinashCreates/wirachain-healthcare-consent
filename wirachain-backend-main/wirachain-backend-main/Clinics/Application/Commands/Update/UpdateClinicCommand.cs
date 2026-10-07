namespace wirachain_backend.Clinics.Application.Commands.Update;

public class UpdateClinicCommand
{
    public string Ruc { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public IList<long> MedicalTestIds { get; set; } = new List<long>();
}