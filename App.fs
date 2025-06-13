module App

open Feliz
open Feliz.Router
open Page

[<ReactComponent>]
let App () : ReactElement =
    let currentUrl = Router.currentPath ()
    match currentUrl with
    | [ "pages"; s ] ->
      Html.div [
        Page [ s; ]
      ]
    | "pages" :: ls ->
      Html.div [
        Page ls
      ]
    | _ ->
      Html.div [
        Html.p "other"
      ]