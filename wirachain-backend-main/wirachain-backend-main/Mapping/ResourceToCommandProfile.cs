using AutoMapper;
using wirachain_backend.Auth.Application.Commands;
using wirachain_backend.Auth.Application.Commands.Create;
using wirachain_backend.Auth.Application.Commands.Update;
using wirachain_backend.Auth.Application.Requests.Create;
using wirachain_backend.Auth.Application.Requests.Update;
using wirachain_backend.Clinics.Application.Commands;
using wirachain_backend.Clinics.Application.Commands.Create;
using wirachain_backend.Clinics.Application.Commands.Update;
using wirachain_backend.Clinics.Application.Requests.Create;
using wirachain_backend.Clinics.Application.Requests.Update;
using wirachain_backend.Doctors.Application.Requests.Update;
using wirachain_backend.MedicalConsultations.Application.Commands;
using wirachain_backend.MedicalConsultations.Application.Commands.Create;
using wirachain_backend.MedicalConsultations.Application.Requests.Create;
using wirachain_backend.MedicalSpecialties.Application.Commands.Create;
using wirachain_backend.MedicalSpecialties.Application.Commands.Update;
using wirachain_backend.MedicalSpecialties.Application.Requests.Create;
using wirachain_backend.MedicalSpecialties.Application.Requests.Update;
using wirachain_backend.MedicalTests.Application.Commands.Create;
using wirachain_backend.MedicalTests.Application.Commands.Update;
using wirachain_backend.MedicalTests.Application.Requests.Create;
using wirachain_backend.MedicalTests.Application.Requests.Update;
using wirachain_backend.Patients.Application.Commands.Create;
using wirachain_backend.Patients.Application.Commands.Update;
using wirachain_backend.Patients.Application.Requests.Create;
using wirachain_backend.Patients.Application.Requests.Update;
using wirachain_backend.Security.Application.Commands.Create;
using wirachain_backend.Security.Application.Requests.Create;

namespace wirachain_backend.Mapping;

public class ResourceToCommandProfile : Profile
{
    public ResourceToCommandProfile()
    {
        // Doctor
        CreateMap<UpdateDoctorRequest, UpdateUserCommand>();

        // User
        CreateMap<UpdateUserRequest, UpdateUserCommand>();
        CreateMap<RegisterUserRequest, RegisterUserCommand>();
        CreateMap<CreateAccessCredentialsRequest, CreateAccessCredentialsCommand>();
        
        // Patient
        CreateMap<UpdatePatientRequest, UpdatePatientCommand>();
        CreateMap<CreatePatientRequest, CreatePatientCommand>();
        
        // MedicalTest
        CreateMap<CreateMedicalTestRequest, CreateMedicalTestCommand>();
        CreateMap<UpdateMedicalTestRequest, UpdateMedicalTestCommand>();
        
        // MedicalSpecialty
        CreateMap<CreateMedicalSpecialtyRequest, CreateMedicalSpecialtyCommand>();
        CreateMap<UpdateMedicalSpecialtyRequest, UpdateMedicalSpecialtyCommand>();
        
        // Clinic
        CreateMap<CreateClinicRequest, CreateClinicCommand>();
        CreateMap<UpdateClinicRequest, UpdateClinicCommand>();
        
             
        // MedicalConsultation
        CreateMap<CreateMedicalConsultationRequest, CreateMedicalConsultationCommand>();

    }
}