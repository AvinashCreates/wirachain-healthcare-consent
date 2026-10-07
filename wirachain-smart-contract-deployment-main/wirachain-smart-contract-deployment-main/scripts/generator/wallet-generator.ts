import { create } from "domain";
import { ethers } from "ethers";
import fs, { writeFileSync } from "fs";
import inquirer from "inquirer";
import path from "path";
import readline from "readline";

// Route
fs.mkdirSync("build", { recursive: true });
const routeText = path.join(__dirname, "build/wallets.txt");
const routeJson = path.join(__dirname, "build/wallets.json");

interface Account {
  walletAddress: string; // This is also public.
  privateKey: string;
  balanceEth: number;
  balanceWei: string;
  balanceHex: string;
  mnemonicPhrase?: string;
}

// Consts
const MAXIMUM_ETHER = 10;
const MINIMUM_ETHER = 1;

function randomFloat(min: number, max: number): string {
  return (Math.random() * (max - min) + min).toString();
}
// Transformation
const etherToWei = (ether: string): bigint => ethers.parseEther(ether);
const weiToHex = (wei: bigint): string => ethers.toBeHex(wei);
const etherToHex = (ether: string): string => weiToHex(etherToWei(ether));

function createWallets(numberWallets: number) {
  const jsonObject: Account[] = [];

  for (let i = 0; i < numberWallets - 1; i++) {
    const randomWei = randomFloat(MINIMUM_ETHER, MAXIMUM_ETHER);
    const generatedWallet = ethers.Wallet.createRandom();

    const newAccount: Account = {
      walletAddress: generatedWallet.address,
      privateKey: generatedWallet.privateKey,
      mnemonicPhrase: generatedWallet.mnemonic?.phrase,
      balanceEth: parseFloat(randomWei),
      balanceWei: etherToWei(randomWei).toString(),
      balanceHex: etherToHex(randomWei),
    };
    jsonObject.push(newAccount);

    if (fs.existsSync(routeText) && i === 0)
      fs.writeFileSync(routeText, `${generatedWallet.address}\n`, "utf-8");
    fs.appendFileSync(routeText, `${generatedWallet.address}\n`, "utf-8");
  }

  writeFileSync(routeJson, JSON.stringify(jsonObject), "utf-8");

  return jsonObject;
}

async function menuSelections() {
  const { numberWallets } = await inquirer.prompt([
    {
      type: "input",
      name: "numberWallets",
      message:
        "🟢 Hi, developer 👋! How many accounts do you want create? 🤔\n Number:",
    },
  ]);

  createWallets(numberWallets);
}

menuSelections();
