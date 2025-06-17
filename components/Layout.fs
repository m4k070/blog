module Layout

open Fable.Core
open Feliz
open Header
open Footer

[<ReactComponent>]
let Layout(children: ReactElement) : ReactElement =  
    Html.div [
        prop.children [
            Header()
            children
            Footer()
        ]
    ]