module Parser

open Fable.Core
open Fable.Core.JS

type convertOptions() =
    let mutable backend: string option = None
    let mutable base_dir: string option = None
    let mutable doctype: string option = None
    let mutable header_footer: bool option = None
    let mutable standalone: bool option = None

type IAsciidoctor =
    abstract convert: string -> convertOptions option -> string

[<ImportDefault("asciidoctor")>]
let asciidoctor: unit -> IAsciidoctor = jsNative
