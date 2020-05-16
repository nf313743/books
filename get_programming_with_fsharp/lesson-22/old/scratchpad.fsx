open System.Collections.Generic
let myPrint x = printfn "%A" x

type Customer = {Name:string; SafetyScore:int option; YearPassed:int}

let customers = 
    [
        {Name = "Fred Smith"; SafetyScore= Some 550;YearPassed=1980}
        {Name = "Jane Dunn"; SafetyScore=None; YearPassed=1980}
    ]

let calculateAnnualPremium customer =
    match customer.SafetyScore with 
    | Some 0 -> 250 
    | Some x when x < 0 -> 400
    | Some x when x > 0 -> 150
    | None ->
            printfn "No score supplied.  Using temporary premium."
            300

customers 
|> List.map calculateAnnualPremium
|> myPrint

let tryLoadCustomer id = 
    match id with
    | x when x >= 2 && x <= 7 -> Some (sprintf "Customer %i" x)
    | _ -> None

[0 .. 10]
|> List.choose tryLoadCustomer
|> List.iter myPrint
