using System.Collections.Immutable;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.Doctors.Domain.Facade;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Doctors.Domain.Repositories;
using wirachain_backend.MedicalSpecialties.Domain.Repositories;
using wirachain_backend.Patients.Domain.Repositories;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Permissions.Domain.Repositories;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Doctors.Facades;

public class DoctorFacade(
    IPatientRepository patientRepository,
    IClinicRepository clinicRepository,
    IDoctorClinicRepository doctorClinicRepository,
    IPatientClinicPermissionRepository clinicPermissionRepository,
    IMedicalSpecialtyRepository medicalSpecialtyRepository,
    IDoctorMedicalSpecialtyRepository doctorMedicalSpecialtyRepository)
    : IDoctorFacade
{
    public async Task AssignClinic(Doctor existingDoctor, long clinicId)
    {
        var existingClinic = await clinicRepository.FindAsync(clinicId);
        if (existingClinic == null)
            throw new KeyNotFoundException("Clinic not found");
        existingDoctor.DoctorClinics.Add(new DoctorClinic
        {
            Clinic = existingClinic
        });
    }

    public async Task AddClinicsAsync(Doctor doctor, IList<long> clinicIds)
    {
        Console.WriteLine($"Counting is {clinicIds.Count}");
        if (!clinicIds.Any())
            return;

        // Existing id's
        var existingClinicIdsFromDoctor = doctor.DoctorClinics.Select(dc => dc.ClinicId).ToHashSet();

        // Excepting repeated id's
        var newClinicIds = clinicIds.Except(existingClinicIdsFromDoctor).ToList();
        if (!newClinicIds.Any())
            return;

        var newClinics = (await clinicRepository.ListClinicsByListIdAsync(newClinicIds)).ToList();
        if (!newClinics.Any())
            return;

        // Adding just for this doctor.
        var doctorClinics = newClinics.Select(currentClinic => new DoctorClinic
        {
            Clinic = currentClinic,
            Doctor = doctor
        }).ToList();

        await doctorClinicRepository.AddRangeAsync(doctorClinics);
    }

    public async Task ReplaceClinicsAsync(Doctor existingDoctor, IList<long> clinicIds)
    {
        if (!clinicIds.Any())
            return;

        // Retrieving clinics
        var replacingClinics = (await clinicRepository.ListClinicsByListIdAsync(clinicIds)).ToList();
        if (!replacingClinics.Any())
            return;

        // Existing id's
        var replacingDoctorClinics = replacingClinics.Select(currentClinic => new DoctorClinic
        {
            Clinic = currentClinic,
            Doctor = existingDoctor
        }).ToList();

        // Replacing
        existingDoctor.DoctorClinics = replacingDoctorClinics;
    }

    public async Task AddSpecialtiesAsync(Doctor doctor, IList<long> specialtyIds)
    {
        if (!specialtyIds.Any())
            return;
        var existingSpecialtyIds = doctor.DoctorMedicalSpecialties.Select(de => de.MedicalSpecialtyId).ToHashSet();
        var newSpecialtyIds = specialtyIds.Except(existingSpecialtyIds).ToList();

        if (!newSpecialtyIds.Any())
            return;
        
        // Retrieving Specialties
        var newSpecialties =
            (await medicalSpecialtyRepository.ListMedicalSpecialtiesByIdListAsync(newSpecialtyIds)).Select(ms =>
                new DoctorMedicalSpecialty
                {
                    MedicalSpecialty = ms,
                    Doctor = doctor
                }).ToList();
        await doctorMedicalSpecialtyRepository.AddRangeAsync(newSpecialties);
    }

    public async Task ReplaceSpecialtiesAsync(Doctor doctor, IList<long> specialtyIds)
    {
        if (!specialtyIds.Any())
            return;

        // Retrieving Specialties
        var replacingSpecialties = (await medicalSpecialtyRepository.ListMedicalSpecialtiesByIdListAsync(specialtyIds)).ToList();
        if (!replacingSpecialties.Any())
            return;
        
        // Selecting
        var replacingDoctorMedicalSpecialties =
            replacingSpecialties.Select(ms =>
                new DoctorMedicalSpecialty
                {
                    MedicalSpecialty = ms,
                    Doctor = doctor
                }).ToList();
        
        // Replacing
        doctor.DoctorMedicalSpecialties = replacingDoctorMedicalSpecialties;
    }

    public async Task RequestPatientPermissionAsync(Doctor existingDoctor, long clinicId, Guid patientId)
    {
        Console.WriteLine("Chambi!");
        var existingClinic = await clinicRepository.FindAsync(clinicId);
        if(existingClinic is null)
            throw new KeyNotFoundException("Clinic not found");
        var existingPatient = await patientRepository.FindAsync(patientId);
        if (existingPatient is null)
            throw new KeyNotFoundException("Patient not found");
        
        
        var existingPermission = await clinicPermissionRepository.FindClinicPermissionByClinicIdAndPatientIdAsync(clinicId, patientId);
        if (existingPermission is not null)
        {
            switch (existingPermission.PermissionStatus)
            {
                case PermissionStatus.Approved:
                    throw new ApplicationException(
                        $"Permission with clinic ID {clinicId} already exist with approved permission.");
                case PermissionStatus.Pending:
                    throw new ApplicationException(
                        $"Permission with clinic ID {clinicId} already exist with pending permission. Please wait for confirmation.");
            }
        }
        
        existingDoctor.PatientClinicsPermissions.Add(new PatientClinicPermission
        {
            Clinic = existingClinic,
            Patient = existingPatient,
            IsRequired = true,
            IsActive = false,
            PermissionStatus = PermissionStatus.Pending
        });
    }


    public async Task UpdateFirstClinic(Doctor existingDoctor, long clinicId)
    {
        var existingClinic = await clinicRepository.FindAsync(clinicId);
        if (existingClinic == null)
            throw new KeyNotFoundException("Clinic not found");
        // Validating if it has already a assigned clinic
        var existingDoctorClinics = await doctorClinicRepository.GetDoctorClinicsByDoctorId(existingDoctor.Id);
        var enumerable = existingDoctorClinics.ToList();
        var doctorClinics = existingDoctorClinics as DoctorClinic[] ?? enumerable.ToArray();
        Console.WriteLine(doctorClinics.Length);
        if (!doctorClinics.Any())
            await AssignClinic(existingDoctor, clinicId);
        enumerable.First().Clinic = existingClinic;
    }

    public async Task RemoveClinic()
    {
        var existingClinic = await clinicRepository.FindAsync(1);
    }
}