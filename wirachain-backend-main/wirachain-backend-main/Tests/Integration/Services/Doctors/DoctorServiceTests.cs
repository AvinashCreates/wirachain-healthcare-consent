using Moq;
using wirachain_backend.Doctors.Application.Commands.Create;
using wirachain_backend.Doctors.Domain.Facade;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Doctors.Domain.Repositories;
using wirachain_backend.Doctors.Services;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Domain.Repositories;
using Xunit;

namespace wirachain_backend.Tests.Integration.Services.Doctors;

public class DoctorServiceTests
{
    private readonly Mock<IDoctorRepository> _doctorRepositoryMock;
    private readonly Mock<IDoctorFacade> _doctorFacadeMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly DoctorService _doctorService;

    public DoctorServiceTests()
    {
        _doctorRepositoryMock = new Mock<IDoctorRepository>();
        _doctorFacadeMock = new Mock<IDoctorFacade>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();

        _doctorService = new DoctorService(
            _unitOfWorkMock.Object,
            _doctorRepositoryMock.Object,
            _doctorFacadeMock.Object
        );
    }

    [Fact]
    public async Task AddAsync_WithValidInput_ShouldReturnSuccess()
    {
        // Arrange
        var command = new CreateDoctorCommand
        {
            FirstName = "Ana",
            LastName = "Lopez",
            Gender = Gender.Male,
            Email = "ana@example.com",
            Password = "secure123",
            Phone = "999999999",
            Type = UserType.Doctor,
            ClinicIds = new List<long> { 1 },
            MedicalSpecialtyIds = new List<long> { 101 }
        };

        _doctorRepositoryMock.Setup(r => r.FindByEmailAsync(command.Email))
            .ReturnsAsync((Doctor)null); // No existe doctor con ese email

        _doctorFacadeMock.Setup(f => f.AddClinicsAsync(It.IsAny<Doctor>(), command.ClinicIds))
            .Returns(Task.CompletedTask);

        _doctorFacadeMock.Setup(f => f.AddSpecialtiesAsync(It.IsAny<Doctor>(), command.MedicalSpecialtyIds))
            .Returns(Task.CompletedTask);

        _doctorRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Doctor>()))
            .Returns(Task.CompletedTask);

        _unitOfWorkMock.Setup(u => u.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.CommitTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var response = await _doctorService.AddAsync(command);

        // Assert
        Assert.True(response.Success);
        Assert.Equal(command.Email, response.Data.Email);

        _doctorRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Doctor>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitTransactionAsync(), Times.Once);
    }
}