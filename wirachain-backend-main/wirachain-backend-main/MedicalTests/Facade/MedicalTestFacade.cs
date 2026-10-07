using wirachain_backend.MedicalTests.Application.Commands.Create;
using wirachain_backend.MedicalTests.Application.Commands.Update;
using wirachain_backend.MedicalTests.Domain.Facade;
using wirachain_backend.MedicalTests.Domain.Models;

namespace wirachain_backend.MedicalTests.Facade;

public class MedicalTestFacade : IMedicalTestFacade
{
    public MedicalTest BuildMedicalTestFromCommand(CreateMedicalTestCommand command)
    {
        var medicalTest = new MedicalTest
        {
            Name = command.Name,
        };
        return medicalTest;
    }

    public void UpdateMedicalTestFromCommand(MedicalTest medicalTest, UpdateMedicalTestCommand command)
    {
        medicalTest.Name = command.Name;
    }
}