import inquirer from "inquirer";
// import solc from 'solc';
import fs from "fs";
import path from "path";

const contractsDir = path.resolve(__dirname, "../../contracts");
const buildDir = path.resolve(__dirname, "build");

// const solc = require("solc");

var solc = require('solc');

function compile(fileName: string, source: string) {
  console.log("Version: ", solc.version())
  var input = {
    language: "Solidity",
    sources: {
      // Naming property from this object from parameter.
      [fileName]: {
        content: source,
      },
    },
    settings: {
      outputSelection: {
        "*": {
          "*": ["abi", "evm.bytecode", "evm.deployedBytecode"],
        },
      },
    },
  };

  console.log("input", input);

  // Compile
  const output = JSON.parse(solc.compile(JSON.stringify(input)));

  /*
  Format for object compilation.
    {
      contracts: { 'event-permission-contract.sol': { Events: [Object] } },
      sources: { 'event-permission-contract.sol': { id: 0 } }
    }  
  */

  // Create folder.
  fs.mkdirSync("build", { recursive: true });

  console.log(output);
  // Iterates over all .sol files (sources) (output.contracts is type: object)
  for (const solFileName in output.contracts) {
    console.log("gaa", path.basename(solFileName));
    const contracts = output.contracts[solFileName];
    for (let contractName in contracts) {
      // Iterates over all contracts in that .sol file. (contracts is type: object)
      const { abi, evm } = contracts[contractName]; // These are called events.
      console.log("EVM", evm);
      const bytecode = evm.bytecode.object;
      const deployedBytecode = evm.deployedBytecode.object;
      // console.log("---------");
      // console.log("abi: ", abi);
      // console.log("evm: ", evm);
      const artifact = { abi, bytecode, deployedBytecode };
      const contractJsonFile = path.join(
        buildDir,
        `${path.basename(solFileName, ".sol")}_${contractName}.json`
      );

      fs.writeFileSync(contractJsonFile, JSON.stringify(artifact));
    }
  }
}

async function menuSelections() {
  const files = await fs.readdirSync(contractsDir);

  if (files.length == 0) {
    console.error("There are no contracts ❌");
  }

  console.log(files);

  const { selectedFile } = await inquirer.prompt([
    {
      type: "list",
      name: "selectedFile",
      message:
        "🟢 Hi, developer 👋! How many accounts do you want create? 🤔\n Number:",
      choices: files.filter((f) => f.endsWith(".sol")), // Filter by extension.
      filter: (val) => path.join(contractsDir, val), // Transforms selection to actual path in folders. selectedFile will be modified.
    },
  ]);

  const baseNameFile = path.basename(selectedFile);
  const source = fs.readFileSync(selectedFile).toString();
  compile(baseNameFile, source);

  console.log(`File Name: ${path.basename(selectedFile)}`);
  // console.log(`✔️ Source: ${fs.readFileSync(selectedFile)}`);
}

menuSelections();
