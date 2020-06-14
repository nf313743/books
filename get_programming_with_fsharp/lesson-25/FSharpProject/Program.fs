// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    let tony = CSharpProject.Person "Tony"
    tony.PrintName()
    0 // return an integer exit code
