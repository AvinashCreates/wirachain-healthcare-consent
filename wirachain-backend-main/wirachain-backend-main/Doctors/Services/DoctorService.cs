using wirachain_backend.Auth.Application.Requests.Patch;
using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Auth.Domain.Services.Communication;
using wirachain_backend.Doctors.Application.Commands.Create;
using wirachain_backend.Doctors.Application.Commands.Update;
using wirachain_backend.Doctors.Domain.Facade;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Doctors.Domain.Repositories;
using wirachain_backend.Doctors.Domain.Services;
using wirachain_backend.Doctors.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Doctors.Services;

public class DoctorService(IUnitOfWork unitOfWork, IDoctorRepository doctorRepository, IDoctorFacade doctorFacade)
    : IDoctorService
{
    public async Task<DoctorResponse> FindAsync(Guid id)
    {
        var existingDoctor = await doctorRepository.FindAsync(id);
        if (existingDoctor == null)
            return new DoctorResponse("Doctor not found");
        return new DoctorResponse(existingDoctor);
    }

    public async Task<DoctorResponse> AddAsync(CreateDoctorCommand doctor)
    {
        try
        {
            var existingDoctor = await doctorRepository.FindByEmailAsync(doctor.Email);
            if (existingDoctor != null)
                throw new ApplicationException("Doctor with this email already exists");

            await unitOfWork.BeginTransactionAsync();

            // Generating New Doctor
            var newDoctor = new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Gender = doctor.Gender,
                DateOfBirth = doctor.DateOfBirth,
                Email = doctor.Email,
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(doctor.Password),
                Phone = doctor.Phone,
                UserType = doctor.Type
            };

            // Assigning Clinics
            await doctorFacade.AddClinicsAsync(newDoctor, doctor.ClinicIds);
            // Adding Specialty
            await doctorFacade.AddSpecialtiesAsync(newDoctor, doctor.MedicalSpecialtyIds);

            await doctorRepository.AddAsync(newDoctor);

            await unitOfWork.CommitTransactionAsync();
            return new DoctorResponse(newDoctor);
        }
        catch (Exception e)
        {
            return new DoctorResponse(e.Message);
        }
    }


    public async Task<DoctorResponse> UpdateAsync(Guid doctorId, UpdateDoctorCommand doctor)
    {
        try
        {
            var existingDoctor = await doctorRepository.FindAsync(doctorId);
            if (existingDoctor == null)
                throw new ApplicationException("Doctor not found");

            await unitOfWork.BeginTransactionAsync();

            existingDoctor.Email = doctor.User.Email;
            existingDoctor.Phone = doctor.User.Phone;
            existingDoctor.FirstName = doctor.FirstName;
            existingDoctor.LastName = doctor.LastName;
            existingDoctor.UpdatedAt = DateTime.Now;
            existingDoctor.Gender = doctor.Gender;

            // Replace clinics
            await doctorFacade.ReplaceClinicsAsync(existingDoctor, doctor.ClinicIds);

            // Replace specialties
            await doctorFacade.ReplaceSpecialtiesAsync(existingDoctor, doctor.MedicalSpecialtyIds);

            doctorRepository.Update(existingDoctor);

            await unitOfWork.CommitTransactionAsync();
            return new DoctorResponse(existingDoctor);
        }
        catch (Exception e)
        {
            return new DoctorResponse(e.Message);
        }
    }

    public async Task<DoctorResponse> RemoveAsync(Guid doctorId)
    {
        try
        {
            var existingDoctor = await doctorRepository.FindAsync(doctorId);
            if (existingDoctor == null)
                throw new ApplicationException("Doctor not found");

            await unitOfWork.BeginTransactionAsync();

            doctorRepository.Remove(existingDoctor);

            await unitOfWork.CommitTransactionAsync();
            return new DoctorResponse(existingDoctor);
        }
        catch (Exception e)
        {
            return new DoctorResponse(e.Message);
        }
    }

    public async Task<PageResult<Doctor>> FindByPageAsync(int pageIndex, int pageSize, string searchTerm)
    {
        return await doctorRepository.PageAsync(pageIndex, pageSize, searchTerm);
    }

    public async Task<PageResult<Doctor>> PageByAdminIdAsync(int pageIndex, int pageSize, string searchTerm,
        Guid adminId)
    {
        return await doctorRepository.PageByAdminIdAsync(pageIndex, pageSize, searchTerm, adminId);
    }

    public async Task<DoctorResponse> AssignDoctorToClinicAsync(Guid doctorId, long clinicId)
    {
        var existingDoctor = await doctorRepository.FindAsync(doctorId);
        if (existingDoctor == null)
            throw new ApplicationException("Doctor not found");
        try
        {
            await doctorFacade.AssignClinic(existingDoctor, clinicId);
            return new DoctorResponse(existingDoctor);
        }
        catch (Exception e)
        {
            throw new ApplicationException(e.Message);
        }
    }

    public async Task ChangePasswordAsync(Guid doctorId, PatchPasswordRequest patchPasswordRequest)
    {
        var existingDoctor = await doctorRepository.FindAsync(doctorId);
        if (existingDoctor == null)
            throw new KeyNotFoundException("Doctor not found");
        try
        {
            await unitOfWork.BeginTransactionAsync();
            existingDoctor.HashedPassword = BCrypt.Net.BCrypt.HashPassword(patchPasswordRequest.Password);
            await unitOfWork.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException($"{e.Message}");
        }
    }

    public async Task RequestPatientPermissionAsync(Guid doctorId, long clinicId, Guid patientId)
    {
        var existingDoctor = await doctorRepository.FindAsync(doctorId);
        if (existingDoctor is null)
            throw new KeyNotFoundException("Doctor not found");

        try
        {
            await unitOfWork.BeginTransactionAsync();
            await doctorFacade.RequestPatientPermissionAsync(existingDoctor, clinicId, patientId);
            await unitOfWork.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            throw new ApplicationException(e.Message);
        }
    }
}