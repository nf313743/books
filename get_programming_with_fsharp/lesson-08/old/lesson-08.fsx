let getDestination n =
    match n with
    | "home" -> 25
    | "office" -> 50
    | "stadium" -> 25
    | "gasstation" -> 10
    | _ -> 0

let gasIncrease n =
    n + 50

let canTravelThatFar currentUnits destination = 
    let x = currentUnits - (getDestination destination)
    x > 0
    
let starting = 30
let result = canTravelThatFar starting "office"

printfn "%b" result

let result2 = canTravelThatFar (gasIncrease starting) "office"
printfn "%b" result2
