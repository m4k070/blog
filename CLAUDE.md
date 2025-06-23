# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a blog application built with F# and Fable, compiled to TypeScript and bundled with Vite. The application uses React with Feliz for the frontend, and renders AsciiDoc content from the `contents/` directory.

## Architecture

- **F# Source**: All application logic is written in F#, located in the root directory and `components/` folder
- **Fable Compilation**: F# code is compiled to TypeScript using Fable
- **Content Management**: Blog posts and pages are stored as AsciiDoc files in `contents/posts/` and `contents/pages/`
- **Routing**: Uses Feliz.Router for client-side routing (`/pages/pagename` maps to `contents/pages/pagename.adoc`)
- **Content Parsing**: AsciiDoc files are parsed using the `asciidoctor` npm package

## Development Commands

### Start Development Server
```bash
# Start Fable watch mode (compiles F# to TypeScript)
dotnet fable watch --outDir dist-fable

# Alternative command from README (compiles and runs TypeScript compiler)
dotnet fable watch --lang typescript --run pnpx tsc Program.fs.ts --target es2022 --watch --preserveWatchOutput

# Start Vite dev server
pnpm dev
```

### Build
```bash
# Compile F# to TypeScript
dotnet fable
```

## File Structure

- `Program.fs` - Entry point, mounts React app to DOM
- `App.fs` - Main application component with routing logic
- `components/` - React components (Page, Layout, Header, Footer, Sidebar)
- `lib/Parser.fs` - AsciiDoc parser interface
- `contents/` - Static content directory served by Vite
  - `pages/` - Page content as `.adoc` files
  - `posts/` - Blog post content as `.adoc` files

## Dependencies

- **Fable packages**: Core, Browser.Dom, Fetch
- **Feliz**: React bindings for F#
- **Feliz.Router**: Client-side routing
- **asciidoctor**: Content parsing
- **Vite**: Build tool and dev server