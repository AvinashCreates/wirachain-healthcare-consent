using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.Clinics.Repositories;
using wirachain_backend.Doctors.Domain.Repositories;
using wirachain_backend.MedicalConsultations.Application.Commands;
using wirachain_backend.MedicalConsultations.Application.Commands.Create;
using wirachain_backend.MedicalConsultations.Domain.Facades;
using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.MedicalConsultations.Domain.Repositories;
using wirachain_backend.MedicalTests.Domain.Models;
using wirachain_backend.MedicalTests.Domain.Repositories;
using wirachain_backend.Patients.Domain.Repositories;

namespace wirachain_backend.MedicalConsultations.Facades;

public class MedicalConsultationFacade(IPatientRepository patientRepository, IDoctorRepository doctorRepository, IClinicRepository clinicRepository, IMedicalTestRepository medicalTestRepository, IConsultationMedicalTestRepository consultationMedicalTestRepository) : IMedicalConsultationFacade
{
    public MedicalConsultation BuildMedicalConsultationFromCommand(CreateMedicalConsultationCommand command)
    {
        return new MedicalConsultation
        {
            VisitReason = command.VisitReason,
            NextAppointmentDate = command.NextAppointmentDate,
            Notes = command.Notes,
            CheckInDateTime = command.CheckInDateTime,
            CheckOutDateTime = command.CheckOutDateTime,
        };
    }

    public async Task BookMedicalConsultationAsync(MedicalConsultation medicalConsultation, Guid doctorId, Guid patientId,
        long clinicId)
    {
        var existingPatient = await patientRepository.FindAsync(patientId);
        if (existingPatient is null)
            throw new KeyNotFoundException("Patient not found");
        
        var existingDoctor = await doctorRepository.FindAsync(doctorId);
        if(existingDoctor is null)
            throw new KeyNotFoundException("Doctor not found");
        
        var existingClinic = await clinicRepository.FindAsync(clinicId);
        if (existingClinic is null)
            throw new KeyNotFoundException("Clinic not found");
        
        medicalConsultation.Patient = existingPatient;
        medicalConsultation.DoctorInCharge = existingDoctor;
        medicalConsultation.Clinic = existingClinic;
    }

    public async Task AddAdditionalMedicalTests(MedicalConsultation medicalConsultation, IList<long> medicalTestIds)
    {
        var medicalTests = await medicalTestRepository.ListByListMedicalTestId(medicalTestIds);

        var newAdditionalMedicalTest = medicalTests.Select(mt => new ConsultationMedicalTest
        {
            MedicalTest = mt,
            MedicalConsultation = medicalConsultation
        });
        
        await consultationMedicalTestRepository.AddRangeAsync(newAdditionalMedicalTest);
    }
}