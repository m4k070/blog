module App

open Feliz
open Feliz.Router
open Page
open Post
open PostList

[<ReactComponent>]
let App () : ReactElement =
    let currentUrl = Router.currentPath ()

    match currentUrl with
    | [ "pages"; s ] -> Html.div [ Page [ s ] ]
    | "pages" :: ls -> Html.div [ Page ls ]
    | [ "posts"; filename ] -> Html.div [ Post filename ]
    | [ "posts" ] -> Html.div [ PostList() ]
    | [] -> Html.div [ PostList() ]
    | _ -> Html.div [ Html.p "404" ]
