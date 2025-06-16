module Parser

open Fable.Core

type IAsciidoctor = 
    abstract convert: string -> string

[<ImportDefault("asciidoctor")>]
let asciidoctor: unit -> IAsciidoctor = jsNative