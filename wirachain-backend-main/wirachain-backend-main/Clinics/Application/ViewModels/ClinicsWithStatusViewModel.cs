namespace wirachain_backend.Clinics.Application.ViewModels;

public class ClinicsWithStatusViewModel
{
    public long Id { get; set; }
    public string Ruc { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsRequired { get; set; }
}