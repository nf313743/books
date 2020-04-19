open System.IO
open System

let myprint x = printfn "%A" x

type FootballResult =
    { HomeTeam: string
      AwayTeam: string
      HomeGoals: int
      AwayGoals: int }

let create (ht, hg) (at, ag) =
    { HomeTeam = ht
      AwayTeam = at
      HomeGoals = hg
      AwayGoals = ag }

let results =
    [ create ("Messiville", 1) ("Ronaldo City", 2)
      create ("Messiville", 1) ("Bale Town", 3)
      create ("Bale Town", 3) ("Ronaldo City", 1)
      create ("Bale Town", 2) ("Messiville", 1)
      create ("Ronaldo City", 4) ("Messiville", 2)
      create ("Ronaldo City", 1) ("Bale Town", 2) ]

// First attempt
results
|> List.filter (fun x -> x.AwayGoals > x.HomeGoals)
|> List.groupBy (fun x -> x.AwayTeam)
|> List.map (fun (x, y) -> (x, (y.Length)))
|> myprint

// Book's answer
let isAwayWin result = result.AwayGoals > result.HomeGoals
results
|> List.filter isAwayWin
|> List.countBy(fun x -> x.AwayTeam)
|> List.sortByDescending(fun (_, x) -> x)
|> myprint

// Arrays are mutable
let numbersArray = [| 1; 2; 3; 4; 6 |]
numbersArray.[0] <- 99
numbersArray |> myprint