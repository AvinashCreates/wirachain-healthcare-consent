[![React](https://img.shields.io/badge/React-61DAFB?logo=react&logoColor=black)](https://reactjs.org/)
[![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dot-net&logoColor=white)](https://dotnet.microsoft.com/)
[![Hyperledger Besu](https://img.shields.io/badge/Hyperledger%20Besu-2E3A87?logo=hyperledger&logoColor=white)](https://besu.hyperledger.org/)
[![ethers.js](https://img.shields.io/badge/ethers.js-3C3C3D?logo=ethereum&logoColor=white)](https://docs.ethers.io/)

---

# 🧬 Wirachain – Datasets Brief Explanation

**Wirachain** is an application that leverages **blockchain technology** to securely record and audit patient data access events. Its main goal is to ensure that clinical information is only accessed by authorized clinics, and only when explicit patient consent is granted.

> ⚡ **Note:** This document describes the **datasets** used for testing and validation, along with an overview of how they interact with the blockchain layer.

---

## 📥 1. Input Dataset

The input dataset simulates real-world interactions in the system. It typically includes:

* 👤 **Users**: Example entries for patients, clinic staff, or administrators.
* ✅ **Access Permissions**: Records indicating whether a patient has granted a clinic permission to access their clinical data.
* 📄 **Smart Contract Transactions**: Simulated events sent to the blockchain to record consent actions.

> 🔹 *Example:* A `users` table may store basic patient information such as names, email, hashed passwords, and roles.

---

## 📤 2. Output Dataset

The output dataset captures results of blockchain transactions and smart contract events:

| 🔢 blockNumber | 🕒 timestamp     | 🔗 txHash   | 🧬 patientGuid                       | 🏥 clinicGuid                        | ✅ access | 📝 message        |
| -------------- | ---------------- | ----------- | ------------------------------------ | ------------------------------------ | -------- | ----------------- |
| 1001           | 2025-11-14 10:01 | 0x1a2b3c... | 550e8400-e29b-41d4-a716-446655440000 | 123e4567-e89b-12d3-a456-426614174000 | true     | "Consent granted" |
| 1002           | 2025-11-14 10:06 | 0x4d5e6f... | 550e8400-e29b-41d4-a716-446655440001 | 123e4567-e89b-12d3-a456-426614174001 | false    | "Consent denied"  |

> ⚡ **Tip:** Each input record corresponds to a blockchain event, ensuring reproducibility and auditability.

---

## 🏗 Architecture Overview

* 💻 **Frontend:** React interface for patients and clinics.
* 🖥 **Backend:** .NET REST API for request handling and validation.
* ⛓ **Blockchain Layer:** Hyperledger Besu with **QBFT** consensus and 3 validator nodes.
* 🔑 **Account Management:** Private accounts generated with **ethers.js**, each linked to a validator node.

---

## 🔄 4. Data Flow

1. Patients provide or deny consent via the frontend.
2. Backend submits the request to the smart contract on the blockchain.
3. Validator nodes process transactions via QBFT consensus.
4. Events are logged on-chain and reflected in the output dataset.
5. Input/output datasets allow testing and verification of correct access control.

---
