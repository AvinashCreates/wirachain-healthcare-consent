// SPDX-License-Identifier: GPL-3.0
pragma solidity ^0.8.26;

contract Events {
  // bytes32 because it's going to be parsed
    event ClinicPatientPermissionChanged(
        bytes32 indexed patientGuid,
        uint256  indexed clinicGuid,
        bool access,
        string message
    );

    function parseGuidToKeccak256(string memory str_guid)
        internal
        pure
        returns (bytes32)
    {
        // Parsing patient GUID to binary format and then to 256 bits (32 Bytes) hash
        bytes memory patientGuidBinary = abi.encode(str_guid);

        // Parsing patient GUID to binary format and then to 256 bits (32 Bytes) hash
        bytes32 patientGuidHash = keccak256(patientGuidBinary);
        return patientGuidHash;
    }


    function grantPatientPermission(string memory str_patient_id, uint256  clinic_id) public {
        // Parsing GUID's pair to 32 Bytes Hash
        bytes32 patientGuidHash = parseGuidToKeccak256(str_patient_id);
        emit ClinicPatientPermissionChanged(patientGuidHash, clinic_id, true, unicode"✅ Granted Access");

    }

    function remokePatientPermission(string memory str_patient_id, uint256  clinic_id) public {
        // Parsing GUID's pair to 32 Bytes Hash
        bytes32 patientGuidHash = parseGuidToKeccak256(str_patient_id);
        emit ClinicPatientPermissionChanged(patientGuidHash, clinic_id, false, unicode"✅ Revoked Access");
    }

}
