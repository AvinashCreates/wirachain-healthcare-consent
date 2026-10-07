using AutoMapper;
using wirachain_backend.Auth.Application.Requests.Create;
using wirachain_backend.Auth.Application.Requests.Update;
using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Clinics.Application.Commands;
using wirachain_backend.Clinics.Application.Commands.Create;
using wirachain_backend.Clinics.Application.Requests.Create;
using wirachain_backend.Clinics.Application.Requests.Update;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Application.Commands.Create;
using wirachain_backend.Doctors.Application.Commands.Update;
using wirachain_backend.Doctors.Application.Requests.Create;
using wirachain_backend.Doctors.Application.Requests.Update;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Security.Domain.Models;
using CreateClinicAdministratorRequest = wirachain_backend.Clinics.Application.Requests.Create.CreateClinicAdministratorRequest;

namespace wirachain_backend.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        // Clinic
        CreateMap<CreateClinicRequest, Clinic>();
        CreateMap<UpdateClinicRequest, Clinic>();

        // Doctor
        CreateMap<CreateDoctorRequest, CreateDoctorCommand>()
            .ForMember(request => request.Email, expression => expression.MapFrom(resource => resource.AccessCredentials.Email))
            .ForMember(request => request.Password,
                expression => expression.MapFrom(resource => resource.AccessCredentials.Password))
            .ForMember(request => request.Phone, expression => expression.MapFrom(resource => resource.AccessCredentials.Phone));
        CreateMap<UpdateDoctorRequest, Doctor>();
        CreateMap<UpdateDoctorRequest, UpdateDoctorCommand>();

        // ClinicAdministrator
        CreateMap<CreateClinicAdministratorRequest, CreateClinicAdministratorCommand>()
            .ForPath(request => request.User.Email, expression => expression.MapFrom(resource => resource.AccessCredentials.Email))
            .ForPath(request => request.User.Password,
                expression => expression.MapFrom(resource => resource.AccessCredentials.Password))
            .ForPath(request => request.User.Phone, expression => expression.MapFrom(resource => resource.AccessCredentials.Phone));
        CreateMap<UpdateClinicAdministratorRequest, ClinicAdministrator>();

        // User
        CreateMap<UpdateUserRequest, User>();
    }
}