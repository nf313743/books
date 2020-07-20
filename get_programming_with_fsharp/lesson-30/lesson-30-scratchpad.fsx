#r "./lib/netstandard2.0/FSharp.Data.dll"

open FSharp.Data

type Dairy = CsvProvider< @"data.csv">
let data = Dairy.GetSample().Rows |> Seq.toArray

let highestPrice = data |> Array.sortByDescending(fun x-> x.PX_SETTLE) |> Array.head

printfn "Highest price is: %f on %O" highestPrice.PX_SETTLE highestPrice.Date