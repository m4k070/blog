open Browser.Dom
open Feliz
open App

let elm = document.getElementById "root"
let root = ReactDOM.createRoot (elm)
root.render (App())
