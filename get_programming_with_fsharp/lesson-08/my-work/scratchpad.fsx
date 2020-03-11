open System

/// Gets the distance to a given destination
let getDistance (destination) =
    match destination with
    | "Gas" -> 10
    | "Home" -> 25
    | "Office" -> 50
    | "Stadium" -> 25
    | _ -> failwith "Unknown destination!"

// Couple of quick tests
getDistance ("Home") = 25
getDistance ("Stadium") = 25
getDistance ("Office") = 25


let calculateRemainingPetrol (currentPetrol: int, distance: int): int =
    if currentPetrol < distance then failwith "Oops! You’ve run out of petrol!"
    currentPetrol - distance


// let distanceToGas = getDistance("Gas")
// calculateRemainingPetrol(25, distanceToGas)
// calculateRemainingPetrol(5, distanceToGas)

let driveTo (petrol:int, destination:string) : int = 
    let distance = getDistance destination
    calculateRemainingPetrol(petrol, distance)


driveTo(100, "Stadium")

 