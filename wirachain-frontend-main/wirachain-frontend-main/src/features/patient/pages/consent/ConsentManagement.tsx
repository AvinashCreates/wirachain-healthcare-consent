import { Button } from "primereact/button"
import { Card } from "primereact/card"
import { Column } from "primereact/column"
import { DataTable } from "primereact/datatable"
import { InputNumber } from "primereact/inputnumber"
import { InputText } from "primereact/inputtext"
import { MultiSelect } from "primereact/multiselect"
import { useState } from "react"
import {
  useGetMyConsentsQuery,
  useGrantConsentMutation,
  useRevokeConsentMutation,
} from "../../../redux"

const RESOURCE_OPTIONS = [
  "Patient",
  "Encounter",
  "Observation",
  "DiagnosticReport",
  "ServiceRequest",
]

function ConsentManagement() {
  const [doctorId, setDoctorId] = useState("")
  const [purpose, setPurpose] = useState("Clinical care coordination")
  const [durationDays, setDurationDays] = useState<number>(7)
  const [resourceTypes, setResourceTypes] = useState<string[]>([
    "Patient",
    "Encounter",
  ])

  const { data: consents = [], isLoading } = useGetMyConsentsQuery()
  const [grantConsent, { isLoading: isGranting }] = useGrantConsentMutation()
  const [revokeConsent, { isLoading: isRevoking }] = useRevokeConsentMutation()

  const handleGrant = async () => {
    if (!doctorId.trim() || !purpose.trim()) {
      return
    }

    await grantConsent({
      doctorId,
      purpose,
      durationDays,
      resourceTypes,
    })

    setDoctorId("")
    setPurpose("Clinical care coordination")
    setDurationDays(7)
    setResourceTypes(["Patient", "Encounter"])
  }

  const handleRevoke = async (consentId: string) => {
    await revokeConsent(consentId)
  }

  return (
    <div className="space-y-5 p-2">
      <Card title="Consent management" subTitle="Patient-controlled access grants">
        <div className="grid gap-4 md:grid-cols-2">
          <div className="flex flex-col gap-2">
            <label htmlFor="doctorId">Doctor ID</label>
            <InputText
              id="doctorId"
              value={doctorId}
              onChange={event => setDoctorId(event.target.value)}
              placeholder="Enter doctor UUID"
            />
          </div>

          <div className="flex flex-col gap-2">
            <label htmlFor="durationDays">Validity (days)</label>
            <InputNumber
              id="durationDays"
              value={durationDays}
              min={1}
              max={30}
              onValueChange={event => setDurationDays(event.value ?? 1)}
            />
          </div>

          <div className="md:col-span-2 flex flex-col gap-2">
            <label htmlFor="purpose">Purpose</label>
            <InputText
              id="purpose"
              value={purpose}
              onChange={event => setPurpose(event.target.value)}
            />
          </div>

          <div className="md:col-span-2 flex flex-col gap-2">
            <label>Allowed resources</label>
            <MultiSelect
              value={resourceTypes}
              options={RESOURCE_OPTIONS}
              onChange={event => setResourceTypes(event.value ?? [])}
              placeholder="Select resources"
              className="w-full"
            />
          </div>
        </div>

        <div className="mt-4 flex justify-end">
          <Button
            label="Grant consent"
            icon="pi pi-check"
            onClick={handleGrant}
            loading={isGranting}
          />
        </div>
      </Card>

      <Card title="Consent registry">
        <DataTable
          value={consents}
          loading={isLoading || isRevoking}
          emptyMessage="No consent records found"
        >
          <Column field="doctorId" header="Doctor" />
          <Column field="purpose" header="Purpose" />
          <Column field="status" header="Status" />
          <Column field="resourceTypes" header="Resources" />
          <Column
            body={(row: { id: string }) => (
              <Button
                icon="pi pi-trash"
                severity="danger"
                text
                onClick={() => handleRevoke(row.id)}
                tooltip="Revoke consent"
              />
            )}
            header="Action"
            style={{ width: "6rem" }}
          />
        </DataTable>
      </Card>
    </div>
  )
}

export default ConsentManagement
