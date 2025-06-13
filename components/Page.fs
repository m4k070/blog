module Page

open Feliz
open Fable.Core
open Fetch

type IReactMarkdownProps =
    abstract children: string with get, set

[<ImportDefault("react-markdown")>]
let Markdown: IReactMarkdownProps -> ReactElement = jsNative

[<ReactComponent>]
let Page(nameList: string list) =
  let content, setContent = React.useState("")

  let loadContent () = async {
        let path = String.concat "/" nameList
        let! response = fetch (path + ".md") [] |> Async.AwaitPromise
        if response.Ok then
            let! text = response.text() |> Async.AwaitPromise
            printfn "Loaded content from %s" path
            printfn "Content: %s" text
            setContent text
        else
            setContent ""
    }

  React.useEffect(loadContent >> Async.StartImmediate, [| |])

  Html.div [
    Markdown {new IReactMarkdownProps with                  
                  member this.children
                      with get (): string = content
                      and set (v: string): unit = 
                          failwith "Not Implemented"}
  ]