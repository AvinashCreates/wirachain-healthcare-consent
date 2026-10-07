namespace wirachain_backend.Patients.Application.Resources.Basic;

public class BasicPatientResource
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
}