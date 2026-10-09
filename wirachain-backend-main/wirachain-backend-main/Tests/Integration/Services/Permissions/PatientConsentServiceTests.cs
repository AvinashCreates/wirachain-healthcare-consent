using Moq;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Doctors.Domain.Repositories;
using wirachain_backend.Permissions.Application.Requests;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Permissions.Domain.Repositories;
using wirachain_backend.Permissions.Services;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Integration.Ethereum.Application.Requests;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Events;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Factory;
using wirachain_backend.Shared.Integration.Fhir.Domain.Services;
using Xunit;

namespace wirachain_backend.Tests.Integration.Services.Permissions;

public class PatientConsentServiceTests
{
    private readonly Mock<IPatientConsentRepository> _consentRepositoryMock = new();
    private readonly Mock<IDoctorRepository> _doctorRepositoryMock = new();
    private readonly Mock<IFhirConsentService> _fhirConsentServiceMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IEventEmitterFactory> _eventEmitterFactoryMock = new();
    private readonly Mock<IEventEmitter<PermissionRequest>> _eventEmitterMock = new();
    private readonly PatientConsentService _service;

    public PatientConsentServiceTests()
    {
        _service = new PatientConsentService(
            _consentRepositoryMock.Object,
            _doctorRepositoryMock.Object,
            _fhirConsentServiceMock.Object,
            _unitOfWorkMock.Object,
            _eventEmitterFactoryMock.Object);

        _unitOfWorkMock.Setup(u => u.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.CommitTransactionAsync()).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.RollbackTrasactionAsync()).Returns(Task.CompletedTask);
        _eventEmitterFactoryMock
            .Setup(factory => factory.Create<PermissionRequest>("GrantPermission"))
            .Returns(_eventEmitterMock.Object);
        _eventEmitterMock
            .Setup(emitter => emitter.EmitEventAsync(0, It.IsAny<PermissionRequest>()))
            .ReturnsAsync("0xabc123");
    }

    [Fact]
    public async Task GrantAsync_WithValidRequest_ShouldPersistConsentAndEmitBlockchainEvent()
    {
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();
        var doctor = new Doctor
        {
            Id = doctorId,
            DoctorClinics = new List<DoctorClinic>
            {
                new()
                {
                    ClinicId = 42,
                },
            },
        };

        var request = new GrantPatientConsentRequest
        {
            DoctorId = doctorId,
            Purpose = "Follow-up consultation",
            DurationDays = 7,
            ResourceTypes = ["Patient", "Encounter"],
        };

        _doctorRepositoryMock.Setup(repo => repo.FindAsync(doctorId)).ReturnsAsync(doctor);
        _fhirConsentServiceMock.Setup(service => service.CreateAsync(
                It.IsAny<Guid>(),
                patientId,
                doctorId,
                request.Purpose,
                It.IsAny<IReadOnlyList<string>>(),
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>()))
            .ReturnsAsync("fhir-consent-1");

        var response = await _service.GrantAsync(patientId, request);

        Assert.Equal("0xabc123", response.BlockchainTransactionHash);
        Assert.Equal("fhir-consent-1", response.FhirConsentId);

        _consentRepositoryMock.Verify(repo => repo.AddAsync(It.Is<PatientConsent>(c =>
            c.PatientId == patientId &&
            c.DoctorId == doctorId &&
            c.Purpose == request.Purpose)), Times.Once);

        _eventEmitterMock.Verify(emitter => emitter.EmitEventAsync(0,
            It.Is<PermissionRequest>(permission =>
                permission.PatientId == patientId &&
                permission.ClinicId == 42)), Times.Once);
    }

    [Fact]
    public async Task RevokeAsync_WithValidConsent_ShouldEmitRevokeEvent()
    {
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();
        var consentId = Guid.NewGuid();
        var doctor = new Doctor
        {
            Id = doctorId,
            DoctorClinics = new List<DoctorClinic>
            {
                new()
                {
                    ClinicId = 77,
                },
            },
        };

        var consent = new PatientConsent
        {
            Id = consentId,
            PatientId = patientId,
            DoctorId = doctorId,
            Purpose = "Consent revoke test",
            ResourceScopesJson = "[\"Patient\"]",
            GrantedAtUtc = DateTime.UtcNow.AddDays(-2),
            ExpiresAtUtc = DateTime.UtcNow.AddDays(10),
            FhirConsentId = "fhir-revoke-1",
        };

        _consentRepositoryMock.Setup(repo => repo.FindByIdAndPatientIdAsync(consentId, patientId)).ReturnsAsync(consent);
        _doctorRepositoryMock.Setup(repo => repo.FindAsync(doctorId)).ReturnsAsync(doctor);
        _eventEmitterFactoryMock
            .Setup(factory => factory.Create<PermissionRequest>("RevokePermission"))
            .Returns(_eventEmitterMock.Object);

        await _service.RevokeAsync(patientId, consentId);

        _eventEmitterMock.Verify(emitter => emitter.EmitEventAsync(0,
            It.Is<PermissionRequest>(permission =>
                permission.PatientId == patientId &&
                permission.ClinicId == 77)), Times.Once);
    }
}
