module Post

open Feliz
open Fable.Core
open Fetch
open Layout

let asciidoctor = Parser.asciidoctor ()

[<ReactComponent>]
let Post (filename: string) =
    let content, setContent = React.useState ("")

    let loadContent () =
        async {
            let path = $"posts/{filename}.adoc"
            let! response = fetch path [] |> Async.AwaitPromise

            if response.Ok then
                let! text = response.text () |> Async.AwaitPromise
                printfn "Loaded content from %s" path
                printfn "%s" text
                setContent text
            else
                setContent ""
        }

    React.useEffect (loadContent >> Async.StartImmediate, [||])

    Layout(Html.div [ prop.dangerouslySetInnerHTML (asciidoctor.convert content None) ])
