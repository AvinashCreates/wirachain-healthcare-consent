import { transferableAbortController } from "node:util"

const nativeAbortController = transferableAbortController()

Object.defineProperty(globalThis, "AbortController", {
  configurable: true,
  value: nativeAbortController.constructor,
})
Object.defineProperty(globalThis, "AbortSignal", {
  configurable: true,
  value: Object.getPrototypeOf(nativeAbortController.signal).constructor,
})

const storage = new Map<string, string>()
const testLocalStorage: Storage = {
  get length() {
    return storage.size
  },
  clear: () => storage.clear(),
  getItem: key => storage.get(key) ?? null,
  key: index => Array.from(storage.keys())[index] ?? null,
  removeItem: key => storage.delete(key),
  setItem: (key, value) => storage.set(key, String(value)),
}

Object.defineProperty(globalThis, "localStorage", {
  configurable: true,
  value: testLocalStorage,
})
