using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Microsoft.Extensions.Options;
using wirachain_backend.Shared.Integration.Fhir.Domain.Services;
using wirachain_backend.Shared.Integration.Fhir.Settings;
using Task = System.Threading.Tasks.Task;

namespace wirachain_backend.Shared.Integration.Fhir.Service;

public class FhirPatientService : IFhirPatientService
{
    private readonly FhirSettings _settings;
    private readonly FhirJsonSerializer _fhirSerializer;
    private readonly FhirJsonParser _fhirJsonParser;
    private readonly HttpClient _httpClient;

    public FhirPatientService(IOptions<FhirSettings> options, FhirJsonSerializer fhirSerializer, HttpClient httpClient, FhirJsonParser fhirJsonParser)
    {
        _fhirSerializer = fhirSerializer;
        _httpClient = httpClient;
        _fhirJsonParser = fhirJsonParser;
        _settings = options.Value;
    }


    public async Task<Patient> CreateAsync(Patient patient)
    {
        var strJson = await _fhirSerializer.SerializeToStringAsync(patient);
        var content = new StringContent(strJson);
        content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json+fhir");
        var response = await _httpClient.PostAsync($"{_settings.BaseUrl}/Patient", content);
        response.EnsureSuccessStatusCode();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        
        return _fhirJsonParser.Parse<Patient>(jsonResponse);
    }

    public async Task<Patient?> FindAsync(string fhirId)
    {
        var response = await _httpClient.GetAsync($"{_settings.BaseUrl}/Patient/{Uri.EscapeDataString(fhirId)}");
        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        return _fhirJsonParser.Parse<Patient>(jsonResponse);
    }

    public async Task<IEnumerable<Patient>> FindByIdentifierAsync(string system, string value)
    {
        var query = Uri.EscapeDataString(system) + "|" + Uri.EscapeDataString(value);
        var response = await _httpClient.GetAsync($"{_settings.BaseUrl}/Patient?identifier={query}");
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var bundle = _fhirJsonParser.Parse<Bundle>(jsonResponse);

        return bundle.Entry?
            .Select(entry => entry.Resource as Patient)
            .Where(patient => patient is not null)
            .Cast<Patient>()
            ?? Enumerable.Empty<Patient>();
    }

    public async Task<Patient> UpdateAsync(string fhirId, Patient patient)
    {
        var strJson = await _fhirSerializer.SerializeToStringAsync(patient);
        var content = new StringContent(strJson);
        content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json+fhir");
        
        var response = await _httpClient.PutAsync($"{_settings.BaseUrl}/Patient/{fhirId}", content);
        response.EnsureSuccessStatusCode();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return _fhirJsonParser.Parse<Patient>(jsonResponse);
    }

    public async Task DeleteAsync(string fhirId)
    {
        var response = await _httpClient.DeleteAsync($"{_settings.BaseUrl}/Patient/{fhirId}");
        response.EnsureSuccessStatusCode();
    }
}