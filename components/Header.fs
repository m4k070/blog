module Header

open Fable.Core
open Feliz

[<ReactComponent>]
let Header() =  
    Html.div [
        Html.h1 "My Blog"
    ]