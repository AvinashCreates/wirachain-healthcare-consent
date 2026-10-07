import { ethers } from "ethers";
import path from "path";
import fs from "fs";

async function readEvents() {
  // Puedes ajustar el rango si deseas

  const JSON_BUILD_PATH = path.resolve(
    __dirname,
    "../compile/build/event-permission-contract-2_Events.json"
  );

  const contractAddress = "0xcf171E178E6348F67F4bE4985CbE4C096c70Cc85";
  const provider = new ethers.JsonRpcProvider("http://localhost:8545");
  const wallet = new ethers.Wallet(
    "0x8fcfc18a4bb9212fd9c0811c96f58c4200420fd836f8af03066df130b2baee05",
    provider
  );
  const artifact = JSON.parse(fs.readFileSync(JSON_BUILD_PATH, "utf-8"));
  const contract = new ethers.Contract(contractAddress, artifact.abi, wallet);

  // This filters all events of type ClinicPatientPermissionChanged.
  const fromBlock = 0;
  const latest = await provider.getBlockNumber();

  for (let i = fromBlock; i <= latest; i += 1000) {
    const end = Math.min(i + 999, latest);
    const logs = await contract.queryFilter(
      contract.filters.ClinicPatientPermissionChanged(),
      i,
      end
    );

    for (const ev of logs) {
      if ("args" in ev) {
        const { patientGuid, clinicGuid, access, message } = ev.args;
        console.log("🧬 Patient GUID Hash: ", patientGuid);
        console.log("🏥 Clinic ID Hash: ", clinicGuid.toString());
        console.log("🔓 Access: ", access);
        console.log("📝 Message: ", message);
        console.log("⛓️ Tx: ", ev.transactionHash);
        console.log("—".repeat(40));
      }
    }
  }
}

readEvents();
