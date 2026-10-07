# Related Work and Gap Analysis

## 1. Overview

Healthcare data management has become increasingly complex due to the distributed nature of clinical information, evolving patient expectations, and the growing need for interoperability across institutions. The literature on secure healthcare data exchange spans several domains, including healthcare interoperability, consent-aware access control, secure clinical information systems, and blockchain-based data governance.

This review examines the major strands of prior work and identifies the gap that motivates the proposed framework: a secure, consent-aware FHIR and permissioned blockchain architecture for interoperable healthcare data exchange among patients, physicians, and clinical laboratories.

---

## 2. FHIR-based Interoperability in Healthcare

Healthcare interoperability is a foundational concern in digital health systems. HL7 FHIR has emerged as one of the most widely discussed standards for improving the exchange of clinical information across different systems. Its resource-based architecture enables structured and interoperable exchange of data such as patient demographics, observations, prescriptions, diagnostics, and treatment information.

Multiple studies have demonstrated the usefulness of FHIR in healthcare integration. The standard allows various systems to exchange data using structured APIs and standardised resource definitions, thereby reducing dependence on proprietary interfaces. This is especially valuable in settings where information must move across departments, hospitals, and laboratories.

FHIR provides a common representation for several resource types that are central to the proposed project, including Patient, Practitioner, Observation, Specimen, ServiceRequest, and DiagnosticReport. These resources align well with clinical workflows involving patient evaluation, test ordering, specimen handling, and result reporting. The standard is also attractive for digital health prototypes because it supports modularity and easier integration with modern web services.

However, while FHIR addresses representation and exchange, it does not by itself provide full patient control over access decisions or immutable auditability. Interoperability alone does not automatically ensure privacy, patient authorization, or trust. For a healthcare system to be both standardised and secure, interoperability must be paired with consent-aware access control and robust audit mechanisms.

---

## 3. Consent-Aware Access Control and Patient-Centric Privacy

A major theme in contemporary healthcare literature is that access control must be patient-centered and context-aware rather than based only on institutional roles. Patients may want to share information with selected physicians, clinics, or laboratories, but only under specific conditions. Access may be limited by purpose, resource type, time window, or existing care relationship.

Role-based access control (RBAC) is widely used in healthcare systems, but it is often insufficient for handling dynamic, patient-controlled sharing. In scenarios involving laboratory requests and diagnostic interpretation, a physician may need a subset of records for a limited period, while the patient may revoke that consent at any time. Such requirements suggest the need for a consent-aware model that supports time-bound authorization, selective data access, and revocation.

Researchers have explored consent models that allow healthcare systems to evaluate access based on patient preferences and policy constraints. These systems aim to support data sharing only when the patient has granted permission, and only under the allowed scope and duration. In practice, this means access control should consider both the identity of the requester and the validity of a consent record.

This is highly relevant to the proposed framework because the project is not only concerned with exchanging data, but with controlling which data is exchanged and under what conditions. Consent-aware policies are therefore essential for protecting patient autonomy while still supporting healthcare operations.

---

## 4. Blockchain for Healthcare Auditability and Trust

Blockchain has been explored extensively in healthcare research because it can support transparency, integrity, and auditability. In healthcare settings, the trustworthiness of access logs, consent changes, and data-sharing events is essential. Blockchain offers a tamper-evident way to record these operations, reducing the risk of unauthorized modifications or hidden access decisions.

Permissioned blockchain platforms are particularly relevant because they support controlled participation and institutional governance. In a healthcare context, not all actors should be freely allowed to interact with the blockchain network. Instead, only approved stakeholders such as hospitals, certified providers, or special entities should be permitted to participate. This aligns with healthcare governance and regulatory requirements.

The literature indicates that blockchain is valuable for maintaining a trustworthy record of who accessed which data, when, and for what purpose. When paired with off-chain storage, blockchain can support privacy-preserving audit trails without storing sensitive patient data directly on the ledger.

This is significant for the proposed framework because the project aims to preserve security and patient privacy while also ensuring traceability. The blockchain layer is best used for permission provenance, event integrity, and audit trails, while clinical data remains off-chain in secure storage. This is a practical and privacy-aware model.

---

## 5. Interoperability and Security in Laboratory Workflows

Healthcare workflows involving clinical laboratories are particularly sensitive because they require the coordination of patient information, physician orders, specimen data, and diagnostic results. These workflows are time-sensitive and often involve several systems that must exchange information reliably and securely.

The literature shows that laboratory systems benefit from structured data exchange models that integrate test requests, order tracking, specimen collection, and result reporting. FHIR is well-suited for this because it can represent relevant resource types such as ServiceRequest, Observation, and DiagnosticReport in a standardised format.

At the same time, laboratory workflows involve privacy risks because they include sensitive patient information and test results. Unauthorized access to lab records can have direct consequences for patient confidentiality and treatment decisions. This context underscores the need for consent-aware access and accountability.

The proposed project is particularly relevant here because it integrates FHIR-based interoperability with patient-controlled access and blockchain-backed auditability—three requirements that are highly important in clinical laboratory data exchange.

---

## 6. Existing Systems and Limitations

Many existing healthcare systems provide robust functionality for record management, authentication, or interoperability, but they often lack one or more of the following properties:

- fine-grained patient consent enforcement
- limited-duration and revocable permissions
- traceable access records
- blockchain-backed provenance
- interoperability using standard health data resources
- support for laboratory-specific data workflows

Some systems are strong in FHIR interoperability but weak in privacy control. Others provide secure access but little interoperability across institutions. Blockchain-based systems improve traceability but may not provide a complete healthcare data model or practical clinical workflow integration.

This indicates a need for an integrated architecture that brings together healthcare data standards, access control, and trust infrastructure. The proposed framework attempts to close this gap by combining FHIR-based modelling, consent-aware policy enforcement, and blockchain-backed auditability into a single architecture.

---

## 7. Gap Analysis

The literature gap can be summarised as follows:

1. FHIR is commonly used for interoperability, but not consistently integrated with patient-controlled consent policies.
2. Consent-aware access control is increasingly discussed, but it is less often connected to laboratory workflows and diagnostic data sharing.
3. Blockchain solutions improve integrity and auditability, but many focus on general healthcare record systems without a clear standardised interoperability layer.
4. There is limited work on unified frameworks that combine FHIR, consent management, and permissioned blockchain provenance in a single healthcare exchange architecture.
5. Patient, physician, and laboratory workflows are often treated separately rather than as a unified clinical ecosystem.

These issues motivate the proposed framework, which addresses the integration of standardised health exchange, patient consent enforcement, and secure access provenance in a single research prototype.

---

## 8. Position of the Proposed Framework

The proposed framework sits at the intersection of three research domains:

- FHIR-based healthcare data interoperability
- patient-centric consent-aware access control
- blockchain-backed trust and provenance

In this architecture, FHIR ensures standardised exchange of healthcare resources, consent management enforces patient-controlled access, and blockchain provides transparent and tamper-evident auditability of permission events.

This combined design is better suited to real-world healthcare scenarios because it balances technical interoperability with privacy preservation and operational accountability.

---

## 9. Summary of Gap Analysis

The reviewed literature demonstrates that healthcare interoperability, consent management, and blockchain-based trust are all important but often studied in isolation. These areas need to be integrated to support secure, patient-controlled, and interoperable clinical data exchange.

The proposed framework addresses this gap by combining FHIR-based interoperability with consent-aware access controls and blockchain-provenance mechanisms for access decisions. This provides a more complete solution for secure exchange among patients, physicians, and laboratory stakeholders.

---

## 10. Conclusion

Existing healthcare systems still struggle to achieve a balance between interoperability, privacy protection, patient autonomy, and auditability. FHIR contributes to standardised data exchange, while consent-aware access models support patient-controlled sharing. Blockchain provides a trustworthy mechanism for recording access and permission events.

However, the literature indicates that these approaches are often developed independently. The gap is a unified framework that integrates patient consent, clinical interoperability, and blockchain-based trust in a healthcare data exchange workflow. The proposed project addresses this gap by proposing a secure, consent-aware FHIR and permissioned blockchain prototype for interoperable healthcare data exchange among patients, physicians, and clinical laboratories.
