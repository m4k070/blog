module Page

open Feliz
open Fable.Core
open Fetch

[<ReactComponent>]
let Page(nameList) =
  let content, setContent = React.useState("")

  let loadContent (path: string) =
    async {
        try
            let! response = fetch path [] |> Async.AwaitPromise
            if response.Ok then
                let! text = response.text() |> Async.AwaitPromise
                return Ok text
            else
                return Error $"HTTP {response.Status}"
        with
        | ex -> return Error ex.Message
    }

  React.useEffect(fun () -> 
    async {
        let! content = loadContent "/contents/pages/about.md" 
        match content with
        | Ok text -> setContent(text)
        | Error msg -> setContent("")
    } |> Async.StartImmediate
  , [| nameList |])

  Html.div [
    Html.p content
  ]