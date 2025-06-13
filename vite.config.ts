import { defineConfig } from "vite";

// https://vitejs.dev/config/
export default defineConfig({
	clearScreen: false,
	publicDir: "contents",
	server: {
		watch: {
			ignored: [
				"**/*.fs", // Don't watch F# files
			],
		},
	},
});
