import { Request, Response } from "express";
import path from "path";
import fs from "fs";

// req: Request, res: Response
export const getPermissionAbi = (req: Request, res: Response) => {
  const artifact = JSON.parse(
    fs.readFileSync(
      path.resolve(
        __dirname,
        "../../../data/compilations/event-permission-contract_Events.json"
      ),
      "utf-8"
    )
  );
  const abi = artifact.abi;
  res.json(abi)
};

// getPermissionAbi();
