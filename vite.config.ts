import { defineConfig } from "vite";
import { postsListPlugin } from "./vite-plugins/posts-list";

// https://vitejs.dev/config/
export default defineConfig({
	clearScreen: false,
	publicDir: "contents",
	plugins: [postsListPlugin()],
	server: {
		watch: {
			ignored: [
				"**/*.fs", // Don't watch F# files
			],
		},
	},
});
