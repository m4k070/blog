module App

open Feliz
open Feliz.Router
open Page

[<ReactComponent>]
let App () : ReactElement =
    let currentUrl = Router.currentPath ()
    match currentUrl with
    | [ "pages" :: s ] ->
      Html.div [
        prop.style [ style.padding 20 ]
        Page s
      ]
    | [ "pages"; s ] ->
      Html.div [
        Html.p "empty"
      ]
    | _ ->
      Html.div [
        Html.p "other"
      ]