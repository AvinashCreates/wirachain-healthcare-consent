import { Router } from "express";
import { getPermissionLogsAsync } from "../api/logs/logs.controller";

const router = Router();

/**
 * @swagger
 *   /logs/patient/{patientId}/clinic/{clinicId}:
 *     get:
 *       summary: Retrieve logs from specific patient and clinic
 *       tags:
 *         - Log Event Viewer
 *       parameters:
 *         - in: path
 *           name: patientId
 *           required: true
 *           description: Patient GUID
 *           schema:
 *             type: string
 *             format: uuid
 *             example: 92360003-631b-4263-8188-199896dcdaab
 *         - in: path
 *           name: clinicId
 *           required: true
 *           description: Clinic numeric ID
 *           schema:
 *             type: integer
 *             format: int64
 *             example: 1
 *       responses:
 *         200:
 *           description: Retrieve logs
 *           content:
 *             application/json:
 *               schema:
 *                 type: array
 *                 items:
 *                   type: object
 *                   properties:
 *                     patientGuid:
 *                       type: string
 *                       example: 92360003-631b-4263-8188-199896dcdaab
 *                     patientGuidHash:
 *                       type: string
 *                       example: 0x12ab...
 *                     clinicGuid:
 *                       type: string
 *                       example: "1"
 *                     access:
 *                       type: boolean
 *                       example: true
 *                     message:
 *                       type: string
 *                       example: "ok"
 *                     txHash:
 *                       type: string
 *                       example: 0xabc123...
 *                     blockNumber:
 *                       type: integer
 *                       example: 12345
 */

router.get("/patient/:patientId/clinic/:clinicId", getPermissionLogsAsync);

export default router;
