open System
open Car

let getDestination() =
    Console.Write("Enter destination: ")
    Console.ReadLine()

let mutable petrol = 100

let getDistance (destination) =
    match destination with
    | "Gas" -> 10
    | "Home" -> 25
    | "Office" -> 50
    | "Stadium" -> 25
    | _ -> failwith "Unknown destination!"


let calculateRemainingPetrol (currentPetrol: int, distance: int): int =
    if currentPetrol < distance then failwith "Oops! You’ve run out of petrol!"
    currentPetrol - distance


let driveTo (petrol:int, destination:string) : int = 
    let distance = getDistance destination
    calculateRemainingPetrol(petrol, distance)


[<EntryPoint>]
let main argv =
    while true do
        try
            let destination = getDestination()
            printfn "Trying to drive to %s" destination
            petrol <- driveTo(petrol, destination)
            petrol <- 
                match destination with
                | "Gas" -> petrol + 50
                | _ -> petrol

            printfn "Made it to %s! You have %d petrol left" destination petrol

        with ex -> printfn "ERROR: %s" ex.Message
    0