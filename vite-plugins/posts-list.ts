import { Plugin } from "vite";
import { readdir } from "fs/promises";
import { join } from "path";

export function postsListPlugin(): Plugin {
	const virtualModuleId = "virtual:posts-list";
	const resolvedVirtualModuleId = `\0${virtualModuleId}`;

	return {
		name: "posts-list",
		resolveId(id) {
			if (id === virtualModuleId) {
				return resolvedVirtualModuleId;
			}
		},
		async load(id) {
			if (id === resolvedVirtualModuleId) {
				try {
					const postsDir = join(process.cwd(), "contents/posts");
					const files = await readdir(postsDir);
					const adocFiles = files.filter((file) => file.endsWith(".adoc"));

					return `export default function getPostFiles() { return ${JSON.stringify(adocFiles)}; }`;
				} catch (error) {
					console.warn("Could not read posts directory:", error);
					return "export default function getPostFiles() { return []; }";
				}
			}
		},
	};
}
