using wirachain_backend.MedicalTests.Application.Resources.Basic;
using wirachain_backend.MedicalTests.Application.Resources.Show;

namespace wirachain_backend.Clinics.Application.Resources.Show;

public class ClinicResource
{
    public long Id { get; set; }
    public string Ruc { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public ClinicAdministratorResource Administrator { get; set; }
    public IList<BasicMedicalTestResource> MedicalTests { get; set; } = new List<BasicMedicalTestResource>();
}