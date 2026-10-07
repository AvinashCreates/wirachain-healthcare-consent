using Microsoft.AspNetCore.Mvc;
using wirachain_backend.Auth.Application.Commands;
using wirachain_backend.Auth.Application.Commands.Create;
using wirachain_backend.Auth.Domain.Facades;
using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Auth.Resources.Show;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Doctors.Domain.Repositories;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Patients.Domain.Repositories;
using wirachain_backend.Security.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Auth.Facade;

public class AccountFacade(
    IPatientRepository patientRepository,
    IClinicAdministratorRepository clinicAdministratorRepository,
    IDoctorRepository doctorRepository) : IAccountFacade
{
    public async Task<User> RegisterUser(RegisterUserCommand command)
    {
        User user = null!;
        switch (command.UserType)
        {
            case UserType.Patient:
                var patient = new Patient
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DateOfBirth = command.DateOfBirth,
                    Email = command.Email,
                    HashedPassword = BCrypt.Net.BCrypt.HashPassword(command.Password),
                    Phone = command.Phone,
                    Gender = command.Gender,
                };
                await patientRepository.AddAsync(patient);
                user = patient;
                break;
            case UserType.Doctor:
                var doctor = new Doctor
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DateOfBirth = command.DateOfBirth,
                    Email = command.Email,
                    HashedPassword = BCrypt.Net.BCrypt.HashPassword(command.Password),
                    Phone = command.Phone,
                    Gender = command.Gender
                };
                await doctorRepository.AddAsync(doctor);
                user = doctor;
                break;
            case UserType.ClinicAdministrator:
                var clinicAdministrator = new ClinicAdministrator
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DateOfBirth = command.DateOfBirth,
                    Email = command.Email,
                    HashedPassword = BCrypt.Net.BCrypt.HashPassword(command.Password),
                    Phone = command.Phone,
                    Gender = command.Gender
                };
                await clinicAdministratorRepository.AddAsync(clinicAdministrator);
                user = clinicAdministrator;
                break;
        }
        return user!;
    }
}