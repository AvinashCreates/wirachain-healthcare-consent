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


    function grantPatientPermission(string memory str_patient_id, uint256  clinic_id) public {
        // Parsing GUID's pair to 32 Bytes Hash
        emit ClinicPatientPermissionChanged(keccak256(bytes(str_patient_id)), clinic_id, true, "ok");

    }

    function revokePatientPermission(string memory str_patient_id, uint256  clinic_id) public {
        // Parsing GUID's pair to 32 Bytes Hash
        emit ClinicPatientPermissionChanged(keccak256(bytes(str_patient_id)), clinic_id, false, "bad");
    }

}
