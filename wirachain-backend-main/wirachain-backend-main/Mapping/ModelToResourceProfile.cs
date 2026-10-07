using AutoMapper;
using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Auth.Resources.Show;
using wirachain_backend.Clinics.Application.Requests.Create;
using wirachain_backend.Clinics.Application.Requests.Update;
using wirachain_backend.Clinics.Application.Resources.Basic;
using wirachain_backend.Clinics.Application.Resources.Show;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Application.Resources.Basic;
using wirachain_backend.Doctors.Application.Resources.Show;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.MedicalConsultations.Application.Resources.Basic;
using wirachain_backend.MedicalConsultations.Application.Resources.Show;
using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.MedicalSpecialties.Application.Resources.Show;
using wirachain_backend.MedicalSpecialties.Domain.Model;
using wirachain_backend.MedicalTests.Application.Resources.Basic;
using wirachain_backend.MedicalTests.Application.Resources.Show;
using wirachain_backend.MedicalTests.Domain.Models;
using wirachain_backend.Patients.Application.Resources.Basic;
using wirachain_backend.Patients.Application.Resources.Show;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Permissions.Application.Resources;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Security.Domain.Models;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        // Clinic
        CreateMap<Clinic, ClinicResource>()
            .ForMember(resource => resource.MedicalTests, opt => opt.MapFrom(entity => entity.MedicalTestClinics));
        CreateMap<Clinic, CreateClinicRequest>();
        CreateMap<Clinic, BasicClinicResource>();   
        CreateMap<Clinic, UpdateClinicRequest>();
        CreateMap<PageResult<Clinic>, PageResult<ClinicResource>>();
        CreateMap<DoctorClinic, BasicClinicResource>()
            .ForMember(dc => dc.Name, expression => expression.MapFrom(clinic => clinic.Clinic.Name))
            .ForMember(dc => dc.Id, expression => expression.MapFrom(clinic => clinic.Clinic.Id))
            .ForMember(dc => dc.Address, expression => expression.MapFrom(clinic => clinic.Clinic.Address))
            .ForMember(dc => dc.Ruc, expression => expression.MapFrom(clinic => clinic.Clinic.Ruc));

        // MedicalTest
        CreateMap<MedicalTest, MedicalTestResource>();
        CreateMap<MedicalTest, BasicMedicalTestResource>();
        CreateMap<PageResult<MedicalTest>, PageResult<MedicalTestResource>>();
        CreateMap<PageResult<MedicalTest>, PageResult<BasicMedicalTestResource>>();
        CreateMap<MedicalTestClinic, BasicMedicalTestResource>()
            .ForMember(resource => resource.Id, expression => expression.MapFrom(clinic => clinic.MedicalTest.Id))
            .ForMember(resource => resource.Name, expression => expression.MapFrom(clinic => clinic.MedicalTest.Name));
        CreateMap<MedicalTestClinic, MedicalTestResource>()
            .ForMember(resource => resource.Name, expression => expression.MapFrom(clinic => clinic.MedicalTest.Name));

        // Doctor
        CreateMap<Doctor, DoctorResource>()
            .ForMember(resource => resource.MedicalSpecialties,
                expression => expression.MapFrom(doctor => doctor.DoctorMedicalSpecialties))
            .ForMember(resource => resource.Clinics,
                expression => expression.MapFrom(doctor => doctor.DoctorClinics));
        CreateMap<Doctor, BasicDoctorResource>();
        CreateMap<PageResult<Doctor>, PageResult<DoctorResource>>();
        
        // ClinicAdministrator
        CreateMap<ClinicAdministrator, ClinicAdministratorResource>();
        CreateMap<ClinicAdministrator, BasicClinicAdministratorResource>();
        CreateMap<PageResult<ClinicAdministrator>, PageResult<ClinicAdministratorResource>>();
        CreateMap<PageResult<ClinicAdministrator>, PageResult<BasicClinicAdministratorResource>>();

        // User
        CreateMap<User, UserResource>();

        // Patient
        CreateMap<Patient, PatientResource>();
        CreateMap<Patient, BasicPatientResource>();
        CreateMap<PageResult<Patient>, PageResult<PatientResource>>();
        CreateMap<PageResult<Patient>, PageResult<BasicPatientResource>>();

        // MedicalSpecialty
        CreateMap<MedicalSpecialty, MedicalSpecialtyResource>();
        CreateMap<PageResult<MedicalSpecialty>, PageResult<MedicalSpecialtyResource>>();
        CreateMap<DoctorMedicalSpecialty, MedicalSpecialtyResource>()
            .ForMember(resource => resource.Name,
                expression => expression.MapFrom(specialty => specialty.MedicalSpecialty.Name))
            .ForMember(resource => resource.Id,
                expression => expression.MapFrom(specialty => specialty.MedicalSpecialty.Id));
        
        // PatientClinicPermission
        CreateMap<PatientClinicPermission, PatientClinicPermissionResource>();
        CreateMap<PageResult<PatientClinicPermission>,PageResult<PatientClinicPermissionResource>>();
        
        // MedicalConsultations
        CreateMap<MedicalConsultation, BasicMedicalConsultationResource>();
        CreateMap<PageResult<MedicalConsultation>, PageResult<BasicMedicalConsultationResource>>();
        CreateMap<MedicalConsultation, MedicalConsultationResource>();
        CreateMap<PageResult<MedicalConsultation>, PageResult<MedicalConsultationResource>>();
    }
}