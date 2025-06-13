module App

open Feliz
open Feliz.Router

[<ReactComponent>]
let App () : ReactElement =
    let currentUrl = Router.currentPath ()

    Html.div
        [ prop.style [ style.padding 20 ]
          prop.children [ Html.h1 "Feliz Router Example"; Html.p $"Current route: {currentUrl}" ] ]
