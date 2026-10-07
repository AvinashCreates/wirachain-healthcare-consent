using AutoMapper;
using wirachain_backend.MedicalConsultations.Application.Commands;
using wirachain_backend.MedicalConsultations.Application.Commands.Create;
using wirachain_backend.MedicalConsultations.Application.Resources.Basic;
using wirachain_backend.MedicalConsultations.Application.Resources.Show;
using wirachain_backend.MedicalConsultations.Domain.Facades;
using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.MedicalConsultations.Domain.Repositories;
using wirachain_backend.MedicalConsultations.Domain.Services;
using wirachain_backend.MedicalConsultations.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalConsultations.Services;

public class MedicalConsultationService(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IMedicalConsultationRepository medicalConsultationRepository,
    IMedicalConsultationFacade medicalConsultationFacade) : IMedicalConsultationService
{
    public async Task<MedicalConsultationResource> FindAsync(Guid consultationId)
    {
        var existingMedicalConsultation = await medicalConsultationRepository.FindAsync(consultationId);
        if (existingMedicalConsultation == null)
            throw new KeyNotFoundException($"Medical consultation ID {consultationId} not found");
        return mapper.Map<MedicalConsultationResource>(existingMedicalConsultation);
    }

    public async Task<MedicalConsultationResponse> BookMedicalConsultationAsync(
        CreateMedicalConsultationCommand command, Guid doctorId, Guid patientId,
        long clinicId)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();
            var medicalConsultation = medicalConsultationFacade.BuildMedicalConsultationFromCommand(command);
            await medicalConsultationFacade.BookMedicalConsultationAsync(medicalConsultation, doctorId, patientId,
                clinicId);
            await medicalConsultationFacade.AddAdditionalMedicalTests(medicalConsultation, command.MedicalTestIds);
            await medicalConsultationRepository.AddAsync(medicalConsultation);
            await unitOfWork.CommitTransactionAsync();
            return new MedicalConsultationResponse(medicalConsultation);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<PageResult<BasicMedicalConsultationResource>> PageByDoctorIdAndClinicIdAsync(int pageIndex,
        int pageSize, Guid doctorId, long clinicId, string searchTerm)
    {
        return mapper.Map<PageResult<BasicMedicalConsultationResource>>(
            await medicalConsultationRepository.PageByDoctorIdAndClinicIdAsync(pageIndex, pageSize, doctorId, clinicId,
                searchTerm));
    }

    public async Task<PageResult<BasicMedicalConsultationResource>> PageByPatientIdAsync(int pageIndex, int pageSize,
        Guid patientId, string searchTerm)
    {
        return mapper.Map<PageResult<BasicMedicalConsultationResource>>(
            await medicalConsultationRepository.PageByPatientIdAsync(pageIndex, pageSize, patientId, searchTerm));
    }

    public async Task<PageResult<BasicMedicalConsultationResource>> PageByClinicAdministratorIdAsync(int pageIndex, int pageSize,
        Guid clinicAdministratorId, string searchTerm)
    {
        return mapper.Map<PageResult<MedicalConsultation>, PageResult<BasicMedicalConsultationResource>>(
            await medicalConsultationRepository.PageByClinicAdministratorIdAsync(pageIndex, pageSize, clinicAdministratorId, searchTerm));
    }

}