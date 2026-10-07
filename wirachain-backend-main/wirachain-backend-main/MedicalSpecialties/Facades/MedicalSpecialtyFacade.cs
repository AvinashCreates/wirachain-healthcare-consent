using wirachain_backend.MedicalSpecialties.Application.Commands.Create;
using wirachain_backend.MedicalSpecialties.Application.Commands.Update;
using wirachain_backend.MedicalSpecialties.Domain.Facades;
using wirachain_backend.MedicalSpecialties.Domain.Model;

namespace wirachain_backend.MedicalSpecialties.Facades;

public class MedicalSpecialtyFacade : IMedicalSpecialtyFacade
{
    public MedicalSpecialty BuildMedicalSpecialtyFromCommand(CreateMedicalSpecialtyCommand command)
    {
        var medicalSpecialty = new MedicalSpecialty
        {
            Name = command.Name,
        };
        return medicalSpecialty;
    }

    public void UpdateMedicalSpecialtyFromCommand(MedicalSpecialty medicalSpecialty, UpdateMedicalSpecialtyCommand command)
    {
        medicalSpecialty.Name = command.Name;
    }
}