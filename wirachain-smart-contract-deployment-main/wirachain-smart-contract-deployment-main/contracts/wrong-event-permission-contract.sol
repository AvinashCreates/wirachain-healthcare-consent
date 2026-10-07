// SPDX-License-Identifier: GPL-3.0
pragma solidity ^0.8.26;

contract Events {
    struct PatientPermissionEvent {
        string PatientGuid;
        string ClinicGuid;
        string PatientName;
        string ClinicName;
    }

    // bytes32 because it's going to be parsed
    event ClinicPatientPermissionChanged(
        bytes32 indexed patientGuid,
        bytes32 indexed clinicGuid,
        bool access
    );

    function parseGuidToKeccak256(string memory str_guid)
        private pure
        returns (bytes32)
    {
        // Parsing patient GUID to binary format and then to 256 bits (32 Bytes) hash
        bytes memory patientGuidBinary = abi.encode(str_guid);

        // Parsing patient GUID to binary format and then to 256 bits (32 Bytes) hash
        bytes32 patientGuidHash = keccak256(patientGuidBinary);
        return patientGuidHash;
    }

    function parseClinicPatientPairGuid(string memory str_patient_guid, string memory str_clinic_guid) private pure returns (bytes32, bytes32) {
        // Parsing patient GUID to binary format and then to 256 bits (32 Bytes) hash
        bytes32 patientGuidHash = parseGuidToKeccak256(str_patient_guid);
        bytes32 clinicGuidHash = parseGuidToKeccak256(str_clinic_guid);
        return (patientGuidHash, clinicGuidHash);
    }

    function addPatientClinicPermission(
        string memory str_patient_guid,
        string memory str_clinic_guid
    ) public {
        // Parsing GUID's pair to 32 Bytes Hash
        (bytes32 patientGuidHash, bytes32 clinicGuidHash) = parseClinicPatientPairGuid(str_patient_guid, str_clinic_guid);

        // Emit this event. Grant access.
        emit ClinicPatientPermissionChanged(
            patientGuidHash,
            clinicGuidHash,
            true
        );
    }

    function revokePatientClinicPermission(
        string memory str_patient_guid,
        string memory str_clinic_guid
    ) public {
         // Parsing GUID's pair to 32 Bytes Hash
        (bytes32 patientGuidHash, bytes32 clinicGuidHash) = parseClinicPatientPairGuid(str_patient_guid, str_clinic_guid);

        // Emit this event. Revoke access.
        emit ClinicPatientPermissionChanged(
            patientGuidHash,
            clinicGuidHash,
            false
        );
    }
}