using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Options;
using wirachain_backend.Shared.Integration.Fhir.Domain.Services;
using wirachain_backend.Shared.Integration.Fhir.Settings;

namespace wirachain_backend.Shared.Integration.Fhir.Service;

public class FhirConsentService(
    IOptions<FhirSettings> options,
    HttpClient httpClient) : IFhirConsentService
{
    private readonly string _baseUrl = options.Value.BaseUrl.TrimEnd('/');
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> CreateAsync(
        Guid consentId,
        Guid patientId,
        Guid doctorId,
        string purpose,
        IReadOnlyList<string> resourceTypes,
        DateTime grantedAtUtc,
        DateTime expiresAtUtc)
    {
        var resource = new
        {
            resourceType = "Consent",
            status = "active",
            scope = new
            {
                coding = new[]
                {
                    new
                    {
                        system = "http://terminology.hl7.org/CodeSystem/consentscope",
                        code = "patient-privacy",
                        display = "Privacy Consent",
                    },
                },
            },
            category = new[]
            {
                new
                {
                    coding = new[]
                    {
                        new
                        {
                            system = "http://loinc.org",
                            code = "59284-0",
                            display = "Consent",
                        },
                    },
                },
            },
            patient = new { reference = $"Patient/{patientId}" },
            dateTime = grantedAtUtc.ToString("O"),
            performer = new[] { new { reference = $"Patient/{patientId}" } },
            provision = new
            {
                type = "permit",
                period = new
                {
                    start = grantedAtUtc.ToString("O"),
                    end = expiresAtUtc.ToString("O"),
                },
                actor = new[]
                {
                    new
                    {
                        role = new
                        {
                            coding = new[]
                            {
                                new
                                {
                                    system = "http://terminology.hl7.org/CodeSystem/v3-ParticipationType",
                                    code = "PRF",
                                    display = "Performer",
                                },
                            },
                        },
                        reference = new { reference = $"Practitioner/{doctorId}" },
                    },
                },
                @class = resourceTypes.Select(resourceType => new
                {
                    coding = new[]
                    {
                        new
                        {
                            system = "http://hl7.org/fhir/resource-types",
                            code = resourceType,
                        },
                    },
                }).ToArray(),
                purpose = new[] { new { text = purpose } },
            },
        };

        var json = JsonSerializer.Serialize(resource);
        using var content = new StringContent(json);
        content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/fhir+json");
        using var response = await _httpClient.PostAsync($"{_baseUrl}/Consent", content);
        response.EnsureSuccessStatusCode();

        var responseNode = JsonNode.Parse(await response.Content.ReadAsStringAsync());
        return responseNode?["id"]?.GetValue<string>() ?? consentId.ToString();
    }

    public async Task RevokeAsync(string fhirConsentId)
    {
        var resourceUrl = $"{_baseUrl}/Consent/{Uri.EscapeDataString(fhirConsentId)}";
        using var getResponse = await _httpClient.GetAsync(resourceUrl);
        getResponse.EnsureSuccessStatusCode();

        var resource = JsonNode.Parse(await getResponse.Content.ReadAsStringAsync())
            ?? throw new InvalidOperationException("HAPI returned an empty Consent resource");
        resource["status"] = "inactive";

        using var content = new StringContent(resource.ToJsonString());
        content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/fhir+json");
        using var putResponse = await _httpClient.PutAsync(resourceUrl, content);
        putResponse.EnsureSuccessStatusCode();
    }
}
