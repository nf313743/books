let printHelper x=
    printfn "%A" x

type Address =
    { Street: string
      Town:string
      City:string}

type Customer =
    { Forename:string
      Surname:string
      Age:int
      Address:Address
      EmailAddress:string
    }

let customer =
    { Forename = "Joe"
      Surname = "Bloggs"
      Age = 30
      Address = 
        { Street = "The street"
          Town = "The town"
          City = "The city"}
      EmailAddress = "joe@bloggs.com"
    }


type Car =
    { 
        Manufacturer:string
        EngineSize:float
        NumberOfDoors:int
        Petrol: int
    }
let myCar = 
    {
        Manufacturer="Toyota"
        EngineSize=1.1
        NumberOfDoors = 4
        Petrol = 100
    }


let updatedCustomer = 
    {
        customer with
            Age = 31
    }

let address01 =
    {
        Address.City = "city"
        Address.Street = "street"
        Address.Town = "Town"
    }
let address02 =
    {
        Address.City = "city"
        Address.Street = "street"
        Address.Town = "Town"
    }

let randomNum =
    (System.Random()).Next(0, 100)

let customerWithRandomAge cust =
    let newCust = 
        {
            cust with
               Age = randomNum
        }
    newCust

let shadowFn = 
    let address03 =
        {
            Address.City = "city"
            Address.Street = "street"
            Address.Town = "Town"
        }
    let address03 = {address03 with City = "city02"}
    printHelper address03.City

shadowFn

let drive car distance =
    match distance with
    | "far" -> {car with Car.Petrol =  car.Petrol / 2}
    | "medium" -> {car with Car.Petrol =  car.Petrol - 10}
    | _ -> {car with Car.Petrol =  car.Petrol - 1}

printHelper (drive myCar "far").Petrol
printHelper (drive myCar "medium").Petrol
printHelper (drive myCar "fsdfds").Petrol