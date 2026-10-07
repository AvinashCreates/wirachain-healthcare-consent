import path from "path";
import swaggerJSDoc from "swagger-jsdoc";

console.log(__dirname);

export const swaggerSpec = swaggerJSDoc({
  definition: {
    info: {
      title: "WiraChain ABI Deployer API",
      version: "1.0.0",
      description: "API for ABI's and deployment",
    },
  },
  apis: [
    `${__dirname}/../../../route/*.route.ts`, // For developing
    `${__dirname}/../../../route/*.route.js`, // For production
  ],
});

console.log(path.resolve(__dirname, "../../../route/*.route.ts"));
