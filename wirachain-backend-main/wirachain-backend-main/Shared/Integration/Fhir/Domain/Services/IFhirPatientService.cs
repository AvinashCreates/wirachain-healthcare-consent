using Hl7.Fhir.Model;
using Task = System.Threading.Tasks.Task;

namespace wirachain_backend.Shared.Integration.Fhir.Domain.Services;

public interface IFhirPatientService
{
    Task<Patient> CreateAsync(Patient patient);
    Task<Patient?> FindAsync(string fhirId);
    Task<IEnumerable<Patient>> FindByIdentifierAsync(string system, string value);
    Task<Patient> UpdateAsync(string fhirId, Patient patient);
    Task DeleteAsync(string fhirId);
}