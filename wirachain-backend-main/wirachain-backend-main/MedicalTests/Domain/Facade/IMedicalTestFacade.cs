using wirachain_backend.MedicalTests.Application.Commands.Create;
using wirachain_backend.MedicalTests.Application.Commands.Update;
using wirachain_backend.MedicalTests.Domain.Models;

namespace wirachain_backend.MedicalTests.Domain.Facade;

public interface IMedicalTestFacade
{
    MedicalTest BuildMedicalTestFromCommand(CreateMedicalTestCommand command);
    void UpdateMedicalTestFromCommand(MedicalTest medicalTest, UpdateMedicalTestCommand command);
}