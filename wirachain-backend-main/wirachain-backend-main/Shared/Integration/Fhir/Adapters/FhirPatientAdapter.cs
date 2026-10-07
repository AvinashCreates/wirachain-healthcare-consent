using Hl7.Fhir.Model;
using wirachain_backend.Shared.Domain.Enumerations;
using Patient = wirachain_backend.Patients.Domain.Models.Patient;

namespace wirachain_backend.Shared.Integration.Fhir.Adapters;

    public static class FhirPatientAdapter
    {
        public static Hl7.Fhir.Model.Patient ToFhirPatient(this Patient patient)
        {
            var fhirPatient = new Hl7.Fhir.Model.Patient
            {
                Id = patient.Id.ToString(),
                Name = new List<HumanName>
                {
                    new()
                    {
                        Family = patient.LastName,
                        Given = [patient.FirstName]
                    }
                },
                Telecom = new List<ContactPoint>
                {
                   new()
                   {
                       System = ContactPoint.ContactPointSystem.Phone,
                       Value = patient.Phone,
                       Use = ContactPoint.ContactPointUse.Mobile
                   },
                   new()
                   {
                       System = ContactPoint.ContactPointSystem.Email,
                       Value = patient.Email,
                       Use = ContactPoint.ContactPointUse.Home
                   }
                },
                Gender = patient.Gender switch
                {
                    Gender.Male => AdministrativeGender.Male,
                    Gender.Female => AdministrativeGender.Female,
                    _ => AdministrativeGender.Unknown
                },
                BirthDate = patient.DateOfBirth.ToString("yyyy-MM-dd"),
                Identifier = new List<Identifier>
                {
                    new()
                    {
                        System = "http://wirachain.org/patients",
                        Value = patient.Id.ToString()
                    }
                }
            };
            return fhirPatient;
        }
    }