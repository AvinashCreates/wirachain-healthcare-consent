using wirachain_backend.MedicalSpecialties.Application.Commands.Create;
using wirachain_backend.MedicalSpecialties.Application.Commands.Update;
using wirachain_backend.MedicalSpecialties.Domain.Model;

namespace wirachain_backend.MedicalSpecialties.Domain.Facades;

public interface IMedicalSpecialtyFacade
{
    MedicalSpecialty BuildMedicalSpecialtyFromCommand(CreateMedicalSpecialtyCommand command);
    void UpdateMedicalSpecialtyFromCommand(MedicalSpecialty medicalSpecialty, UpdateMedicalSpecialtyCommand command);
}