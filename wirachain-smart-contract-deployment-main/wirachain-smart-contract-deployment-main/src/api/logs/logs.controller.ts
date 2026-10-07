import { Request, Response } from "express";
import path from "path";
import { ethers } from "ethers";
import fs from "fs";

const CHUNK_SIZE = 1000;

const provider = new ethers.JsonRpcProvider(process.env.RCP_URL || "http://localhost:8545");

function setPermissionContractData(): {
  permissionArtifact: any;
  permissionContract: ethers.Contract;
} {
  const permissionArtifact = JSON.parse(
    fs.readFileSync(
      path.resolve(
        __dirname,
        "../../../data/addresses/event-permission-contract_Events-address.json"
      ),
      "utf-8"
    )
  );

  const permissionAbi = JSON.parse(
    fs.readFileSync(
      path.resolve(
        __dirname,
        "../../../data/compilations/event-permission-contract_Events.json"
      ),
      "utf-8"
    )
  ).abi;

  const permissionContract = new ethers.Contract(
    permissionArtifact.address,
    permissionAbi,
    provider
  );

  return { permissionArtifact, permissionContract };
}

const { permissionArtifact, permissionContract } = setPermissionContractData();



export const getPermissionLogsAsync = async (req: Request, res: Response) => {
  // Transforms GUID to Hash with keccak256
  const patientGuid = req.params.patientId;
  const hashedPatientGuid = ethers.keccak256(ethers.toUtf8Bytes(patientGuid));
  const clinicId = BigInt(req.params.clinicId);

  const contractAddress = permissionArtifact.address;
  console.log("hashed", hashedPatientGuid)
  // Filter
  const filter = permissionContract.filters.ClinicPatientPermissionChanged(
    hashedPatientGuid,
    1
  );

  const latestBlock = await provider.getBlockNumber();
  const fromBlock = 0;

  const logs: any[] = [];

  for (let i = fromBlock; i <= latestBlock; i += CHUNK_SIZE) {
    const endBlock = Math.min(i + CHUNK_SIZE - 1, latestBlock);
    const chunkLogs = await permissionContract.queryFilter(filter, i, endBlock);
    for (const ev of chunkLogs) {
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
    const filteredChunkLogs = chunkLogs.filter(
      (event) =>
        (event as ethers.EventLog).args.clinicGuid.toString() ===
        clinicId.toString()
    );
    logs.push(...filteredChunkLogs);
  }
  
  const result = logs.map((ev: ethers.EventLog) => ({
    patientGuid: patientGuid ?? "",
    patientGuidHash: ev.args.patientGuid ?? "",
    clinicId: ev.args.clinicId ?? 0,
    access: ev.args.access ?? "",
    message: ev.args.message ?? "",
    txHash: ev.transactionHash ?? "",
    blockNumber: ev.blockNumber ?? "",
  }));
 
  res.json(result);
};

// getPermissionLogsAsync();
