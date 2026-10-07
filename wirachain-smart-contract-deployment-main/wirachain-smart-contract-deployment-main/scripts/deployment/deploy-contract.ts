import { ethers } from "ethers";
import path from "path";
import fs from "fs";
import inquirer from "inquirer";
import type { CompiledContract } from "../../interfaces/contract-compile.interface";

const provider = new ethers.JsonRpcProvider("http://localhost:8545");
const developerWallet = new ethers.Wallet(
  "0x8fcfc18a4bb9212fd9c0811c96f58c4200420fd836f8af03066df130b2baee05",
  provider
); // Put the value

const BUILD_PATH_DIR = path.resolve(__dirname, "../compile/build");
const DATA_DEPLOY_DIR = path.resolve(__dirname, "data");

function getCompiledContract(dataJsonContract: any): CompiledContract {
  const compiledContract: CompiledContract = {
    abi: dataJsonContract.abi,
    bytecode: dataJsonContract.bytecode,
    deployedBytecode: dataJsonContract.deployedBytecode,
  };

  return compiledContract;
}

async function menuSelections(): Promise<string> {
  const filesInBuild = await fs.readdirSync(BUILD_PATH_DIR);

  const { selectedFile } = await inquirer.prompt([
    {
      type: "list",
      message: "Hi, please, select the generated JSON. 🚀",
      name: "selectedFile",
      choices: filesInBuild.filter((f) => f.endsWith(".json")),
      filter: (f) => path.resolve(BUILD_PATH_DIR, f),
    },
  ]);
  console.log(selectedFile);
  console.log(path.parse(selectedFile).name);
  return selectedFile;
}

async function deployContract() {
  const selectedFile = await menuSelections();
  const dataJsonContract = JSON.parse(fs.readFileSync(selectedFile, "utf-8"));

  // Validación básica
  if (!dataJsonContract.abi || !dataJsonContract.bytecode) {
    console.error("❌ El archivo seleccionado no es un contrato válido.");
    return;
  }

  // Getting compiled contract
  const compiledContract = getCompiledContract(dataJsonContract);

  // Contract factory deployer
  const factory = new ethers.ContractFactory(
    compiledContract.abi,
    compiledContract.bytecode,
    developerWallet
  );

  const contract = await factory.deploy();
  console.log("Deploying Contract in: ", contract.target);
  await contract.deploymentTransaction()?.wait();
  console.log("Deployed contract in: ", contract.target);

  // 🔍 Validar que el bytecode en blockchain coincide con el compilado (sin constructor)
  const deployedBytecode = compiledContract.deployedBytecode?.toLowerCase();
  const onChainBytecode = (
    await provider.getCode(contract.target)
  ).toLowerCase();

  console.log("📏 Deployed bytecode length (local):", deployedBytecode.length);
  console.log("📏 On-chain bytecode length:", onChainBytecode.length);
  console.log(
    "📦 Local deployed bytecode (start):",
    deployedBytecode.slice(0, 100)
  );
  console.log("🔗 On-chain bytecode (start):", onChainBytecode.slice(0, 100));

  if (
    deployedBytecode &&
    onChainBytecode.startsWith(`0x${deployedBytecode}`.slice(0, 100))
  ) {
    console.log("✅ Bytecode verificado correctamente en blockchain.");
  } else {
    console.warn("⚠️ El bytecode en cadena NO coincide con el build local.");
  }

  // Guardar dirección
  if (!fs.existsSync(DATA_DEPLOY_DIR)) {
    fs.mkdirSync(DATA_DEPLOY_DIR);
  }

  const outputPath = path.join(DATA_DEPLOY_DIR, `${path.parse(selectedFile).name}-address.json`);

  fs.writeFileSync(
    outputPath,
    JSON.stringify(
      {
        contractName: path.basename(selectedFile),
        address: contract.target,
      },
      null,
      2
    )
  );
}

deployContract();

// menuSelections()
