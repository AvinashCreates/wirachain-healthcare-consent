import { ethers } from "ethers";
import fs from "fs";
import path from "path";
import { keccak256 } from "ethers";

const JSON_BUILD_PATH = path.resolve(
  __dirname,
  "../compile/build/event-permission-contract-2_Events.json"
);

const artifact = JSON.parse(fs.readFileSync(JSON_BUILD_PATH, "utf-8"));
const contractAddress = "0xcf171E178E6348F67F4bE4985CbE4C096c70Cc85";

const provider = new ethers.JsonRpcProvider("http://localhost:8545");
const wallet = new ethers.Wallet(
  "0x8fcfc18a4bb9212fd9c0811c96f58c4200420fd836f8af03066df130b2baee05",
  provider
);

// console.log(JSON.stringify(artifact.abi));
const contract = new ethers.Contract(contractAddress, artifact.abi, wallet);

// async function test() {
//   console.log("📡 Llamando a addPatientClinicPermission...");

//   const tx = await contract.grantPatientPermission(
//     "550e8400-e29b-41d4-a716-446655440000",
//     1
//   );

//   console.log("⏳ Esperando confirmación:", tx.hash);
//   const receipt = await tx.wait();
//   console.log("✅ Transacción confirmada en bloque:", receipt.blockNumber);

//   // Extraer logs del receipt
//   console.log("🔍 Leyendo logs del receipt...");
//   for (const log of receipt.logs) {
//     try {
//       const parsed = contract.interface.parseLog(log);
//       console.log("📦 Evento emitido:");
//       console.log("  🧬 patientGuid:", parsed?.args[0]);
//       console.log("  🏥 clinicGuid:", parsed?.args[1]);
//       console.log("  🔓 access:", parsed?.args[2]);
//     } catch {
//       // Ignorar logs no relacionados
//     }
//   }

//   // Leer logs históricos desde ese bloque
//   const logs = await contract.queryFilter(
//     contract.filters.ClinicPatientPermissionChanged(),
//     receipt.blockNumber,
//     receipt.blockNumber
//   );

//   for (const ev of logs) {
//     if ("args" in ev) {
//       console.log("📥 Evento leído desde el blockchain:");
//       console.log("  🧬", ev.args.patientGuid);
//       console.log("  🏥", ev.args.clinicGuid);
//       console.log("  🔓", ev.args.access);
//     }
//   }
// }

// test().catch(console.error);

async function validate() {
  const bytecodeOnChain = (
    await provider.getCode(contractAddress)
  ).toLowerCase();
  const bytecodeLocal = artifact.deployedBytecode.toLowerCase();
  // console.log(artifact)

  // console.log(bytecodeOnChain);
  // console.log("-----")
  // console.log(bytecodeLocal);
  if (bytecodeOnChain.toLowerCase() === `0x${bytecodeLocal.toLowerCase()}`) {
    console.log("✅ Coinciden los bytecodes base.");
  } else {
    console.log("❌ No coinciden.");
  }

  // // Solo compara los primeros N bytes (usualmente 100-200 es suficiente)
  // if (bytecodeOnChain.startsWith(bytecodeLocal.slice(0, 100))) {
  //   console.log("✅ Coinciden los bytecodes base.");
  // } else {
  //   console.log("❌ No coinciden.");
  // }
}

async function test2() {
  try {
    const tx = await contract.getFunction("grantPatientPermission")(
      "550e8400-e29b-41d4-a716-446655440000",
      1
    );

    const receipt = await tx.wait();
    console.log("✅ Permiso concedido. Tx:", receipt.hash);
  } catch (err: any) {
    console.error("❌ Error al conceder permiso:");

    // Extra info si es un error de ejecución en cadena
    if (err.code === "CALL_EXCEPTION") {
      console.error("🔴 CALL_EXCEPTION: El contrato falló al ejecutar.");
    } else if (err.code === "UNPREDICTABLE_GAS_LIMIT") {
      console.error(
        "⚠️ Gas impredecible. Verifica si los parámetros son válidos."
      );
    }

    // Imprimir mensaje de error
    console.error(err.message);

    // Si quieres ver el objeto completo:
    // console.dir(err, { depth: null });
  }
  for (const frag of contract.interface.fragments) {
    if (frag.type === "function") {
      console.log("🔹 Función encontrada:", frag.format());
    }
  }
}

// async function validate() {
//   const code = await provider.getCode(contractAddress);
//   console.log("🧬 bytecode del contrato:", code);
// }

async function getContract() {
  const code = await provider.getCode(contractAddress);
  console.log("📦 Bytecode encontrado:", code);

  if (code === "0x") {
    console.log("❌ No hay contrato desplegado en esa dirección.");
  } else {
    console.log("✅ Contrato desplegado correctamente.");
  }
}

// getContract()

// validate();
test2().catch(console.error);

async function template() {
  const code = await provider.getCode(contractAddress);
  console.log("📦 Código en cadena:", code);
}

// template()
