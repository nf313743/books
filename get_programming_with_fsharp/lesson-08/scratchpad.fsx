open System

//TODO: Create helper functions to provide the building blocks to implement driveTo.

let getDistance (destination:string) =
    match destination.ToLowerInvariant() with
    | "home" -> 25
    | "office" -> 50
    | "stadium" -> 25
    | "gas" -> 10
    | _ -> failwith "Unknown destination!"

let calculateRemainingPetrol(currentPetrol:int, distance:int) : int =
    let result = currentPetrol - distance
    match result with
    | x when x > 0 -> x
    | _ -> failwith "Oops! You’ve run out of petrol!"

/// Drives to a given destination given a starting amount of petrol
let driveTo (petrol:int, destination:string) = 
    let distanceToGo = getDistance destination
    let remainingPetrol = calculateRemainingPetrol (petrol, distanceToGo)
    match destination.ToLowerInvariant() with
    | "gas" -> remainingPetrol + 50
    | _ -> remainingPetrol

let printHelper x =
    printfn "%A" x
    x
let a = driveTo(100, "Office") |> printHelper

let b = driveTo(a, "Stadium")|> printHelper
let c = driveTo(b, "Gas")|> printHelper
let answer = driveTo(c, "Home")|> printHelper |> ignore