module Sidebar

open Fable.Core
open Feliz

[<ReactComponent>]
let Sidebar(): ReactElement =
    Html.div [
        Html.h2 "Sidebar"
        Html.ul [
            Html.li [ Html.a [ prop.href "/"; prop.text "Top" ] ]
            Html.li [ Html.a [ prop.href "/about"; prop.text "About" ] ]
            Html.li [ Html.a [ prop.href "/contact"; prop.text "Contact" ] ]
        ]
    ]