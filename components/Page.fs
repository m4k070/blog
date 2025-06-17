module Page

open Feliz
open Fable.Core
open Fetch
open Layout

let asciidoctor = Parser.asciidoctor()

[<ReactComponent>]
let Page(nameList: string list) =
  let content, setContent = React.useState("")

  let loadContent () = async {
        let path = String.concat "/" nameList
        let! response = fetch (path + ".adoc") [] |> Async.AwaitPromise
        if response.Ok then
            let! text = response.text() |> Async.AwaitPromise
            printfn "Loaded content from %s" path
            printfn "Content: %s" text
            setContent text
        else
            setContent ""
    }

  React.useEffect(loadContent >> Async.StartImmediate, [| |])

  Layout(
      Html.div [
         prop.dangerouslySetInnerHTML (asciidoctor.convert content) 
      ]
  )