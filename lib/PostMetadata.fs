module PostMetadata

open System
open Fable.Core
open Fetch

type PostMeta = {
    title: string
    date: string
    author: string option
    summary: string option
    filename: string
}

let parseMetadata (content: string) (filename: string) : PostMeta =
    let lines = content.Split('\n')
    let metadataLines = 
        lines
        |> Array.takeWhile (fun line -> line.StartsWith(":") || String.IsNullOrWhiteSpace(line))
        |> Array.filter (fun line -> line.StartsWith(":"))
    
    let getMetaValue (key: string) =
        metadataLines
        |> Array.tryFind (fun line -> line.StartsWith($":{key}:"))
        |> Option.map (fun line -> line.Substring(key.Length + 2).Trim())
    
    {
        title = getMetaValue "title" |> Option.defaultValue filename
        date = getMetaValue "date" |> Option.defaultValue ""
        author = getMetaValue "author"
        summary = getMetaValue "summary"
        filename = filename
    }

let loadPostMetadata (filename: string) = async {
    try
        let! response = fetch $"posts/{filename}" [] |> Async.AwaitPromise
        if response.Ok then
            let! content = response.text() |> Async.AwaitPromise
            return Some (parseMetadata content filename)
        else
            return None
    with
    | _ -> return None
}

[<Import("*", from="virtual:posts-list")>]
let getPostFiles: unit -> string[] = jsNative