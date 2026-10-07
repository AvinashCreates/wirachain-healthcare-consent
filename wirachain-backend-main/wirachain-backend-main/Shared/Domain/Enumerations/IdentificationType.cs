namespace wirachain_backend.Shared.Domain.Enumerations;

public enum IdentificationType
{
    // Universal Documents
    Passport,           // International travel document
    
    // Americas
    DNI,                // National ID (Argentina/Peru/Spain)
    CitizenshipCard,    // National ID card (Colombia/Ecuador)
    CURP,               // Unique population registry code (Mexico)
    RG,                 // General registry ID (Brazil)
    RUT,                // Unique tax identifier (Chile)
    CPF,                // Individual taxpayer registry (Brazil)
    SSN,                // Social Security Number (USA)
    VoterID,            // Electoral credential (Mexico)
    
    // Europe
    NIE,                // Foreigner identification number (Spain)
    FiscalCode,         // Tax identification code (Italy)
    NIF,                // Tax identification number (Portugal/Spain)
    HealthCard,         // National health insurance card (France)
    
    // Asia
    HKID,               // Identity card (Hong Kong)
    Aadhaar,            // Biometric ID number (India)
    NationalID_NPL,     // National identity card (Nepal)
    MyKad,              // National registration ID (Malaysia)
    
    // Africa
    NationalID_EGY,     // National ID number (Egypt)
    NationalID_ZAF,     // National identity document (South Africa)
    CIN,                // National identity card (Algeria)
    
    // Special Cases
    ResidenceCard,      // Residence permit (EU countries)
    RefugeeID           // Refugee identification document (UNHCR)
}