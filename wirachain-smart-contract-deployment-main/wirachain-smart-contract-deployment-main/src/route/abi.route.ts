import { Router } from "express";
import { getPermissionAbi } from "../api/abi/abi.controller";

const router = Router();

/**
 * @swagger
 * /abi/event-permission:
 *   get:
 *     summary: Retrieve ABI from event-permission
 *     tags:
 *       - ABI Dispatcher
 *     responses:
 *       200:
 *         description: Contrato desplegado
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 txHash:
 *                   type: string
 *                   example: "0xabc123..."
 */
router.get("/event-permission", getPermissionAbi);

export default router;
