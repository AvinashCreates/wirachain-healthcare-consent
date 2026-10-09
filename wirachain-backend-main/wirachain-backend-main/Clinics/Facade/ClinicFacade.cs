using Microsoft.EntityFrameworkCore;
using wirachain_backend.Clinics.Application.Commands.Create;
using wirachain_backend.Clinics.Application.Commands.Update;
using wirachain_backend.Clinics.Domain.Facade;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.MedicalTests.Domain.Repositories;
using wirachain_backend.Patients.Domain.Repositories;
using wirachain_backend.Permissions.Domain.Models;

namespace wirachain_backend.Clinics.Facade;

public class ClinicFacade(
    IPatientRepository patientRepository,
    IMedicalTestClinicRepository medicalTestClinicRepository,
    IClinicAdministratorRepository administratorRepository,
    IMedicalTestRepository medicalTestRepository)
    : IClinicFacade
{
    public void UpdateClinicFromCommand(Clinic clinic, UpdateClinicCommand command)
    {
        if (!string.IsNullOrWhiteSpace(command.Name))
            clinic.Name = command.Name;

        if (!string.IsNullOrWhiteSpace(command.Address))
            clinic.Address = command.Address;

        if (!string.IsNullOrWhiteSpace(command.Ruc))
            clinic.Ruc = command.Ruc;
    }

    public Clinic BuildClinicFromCommand(CreateClinicCommand clinic)
    {
        return new Clinic
        {
            Name = clinic.Name,
            Address = clinic.Address,
            Ruc = clinic.Ruc,
        };
    }

    public async Task AssignAdministrator(Clinic clinic, Guid administratorId)
    {
        Console.WriteLine($"Administrator ID: {administratorId}");
        var administrator = await administratorRepository.FindAsync(administratorId);
        if (administrator is null)
            throw new KeyNotFoundException("Administrator not found");
        clinic.Administrator = administrator;
    }

    public async Task AssignPatientToClinicAsync(Clinic clinic, Guid patientId)
    {
        var existingPatient = await patientRepository.FindAsync(patientId);
        if (existingPatient is null)
            throw new KeyNotFoundException("Patient not found");
        var newPatientClinic = new PatientClinicPermission
        {
            Clinic = clinic,
            Patient = existingPatient,
        };
        clinic.PatientClinicsPermissions.Add(newPatientClinic);
    }

    public async Task AddMedicalTestsAsync(Clinic clinic, IList<long> medicalTestIds)
    {
        Console.WriteLine($"AddMedicalTestsAsync: {medicalTestIds.Count}");
        if (!medicalTestIds.Any())
            return;
        
        var existingMedicalIds = clinic.MedicalTestClinics.Select(mc => mc.MedicalTestId).ToHashSet();
        Console.WriteLine($"Adding medical tests for {existingMedicalIds.Count} clinics");
        
        var newMedicalIds = medicalTestIds.Except(existingMedicalIds).ToList();
        if (!medicalTestIds.Any())
            return;
        
        var newMedicalTests =
            (await medicalTestRepository.ListByListMedicalTestId(newMedicalIds)).ToList();
        if (!newMedicalTests.Any())
            return;
        
        var newMedicalTestClinics = newMedicalTests.Select(medicalTest =>
            new MedicalTestClinic
            {
                Clinic = clinic,
                MedicalTest = medicalTest
            }).ToList();
        Console.WriteLine(newMedicalTestClinics.Count);
        await medicalTestClinicRepository.AddRangeAsync(newMedicalTestClinics);
    }

    public async Task ReplaceMedicalTestsAsync(Clinic clinic, IList<long> medicalTestIds)
    {
        if (!medicalTestIds.Any())
            return;

        var replacingClinics =
            (await medicalTestRepository.ListByListMedicalTestId(medicalTestIds)).ToList();

        if (!replacingClinics.Any())
            return;

        var newMedicalTestClinics = replacingClinics.Select(medicalTest => new MedicalTestClinic
        {
            Clinic = clinic,
            MedicalTest = medicalTest
        }).ToList();

        clinic.MedicalTestClinics = newMedicalTestClinics;
    }
}