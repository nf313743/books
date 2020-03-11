type Car =
    { Manufacturer: string
      EngineSize: int
      NumOfDoors: int
      Petrol: float }

let myCar =
    { Manufacturer = "Ford"
      EngineSize = 10
      NumOfDoors = 2
      Petrol = 100.0 }


type Address =
    { Street: string
      Town: string
      City: string }

let address01 =
    { Street = "Strasse"
      Town = "Muenchen"
      City = "Deutschland" }

let address02 =
    { Street = "Strasse"
      Town = "Muenchen"
      City = "Deutschland444" }


address01 = address02


// let drive (car, distance) =
//     if distance = "far" then { car with Petrol = car.Petrol / 2.0 }
//     elif distance = "medium" then {car with Petrol = car.Petrol - 40.0}
//     else {car with Petrol = car.Petrol - 1.0}


let drive (car, distance) =
    match distance with
    | "far" -> { car with Petrol = car.Petrol / 2.0 }
    | "medium" -> { car with Petrol = car.Petrol - 40.0 }
    | _ -> { car with Petrol = car.Petrol - 1.0 }


let firstState = drive (myCar, "far")
let secondState = drive (firstState, "medium")
let finalState = drive (secondState, "short")

printfn "Final pertol: %f" finalState.Petrol
