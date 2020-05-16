type Customer =
    { Name: string
      YearPassed: int
      SafeyScore: int option }


let customers =
    [ { Name = "Fred Smith"
        YearPassed = 1980
        SafeyScore = Some(550) }
      { Name = "Jane Dunn"
        SafeyScore = None
        YearPassed = 1980 } ]


let calculateAnnualPremiumUsed customer = 
    match customer.SafeyScore with
    | Some score -> printfn "Score is: %i" score
    | None -> printfn "No score"

customers |> List.iter calculateAnnualPremiumUsed

type CustomerEntity = {Id: int}


let tryLoadCustomer customerId =   
    match customerId with
    | x when x >=2 && x<=7 -> Some (customerId.ToString())
    | _ -> None

let idList = [ 0..10]

idList |> List.choose tryLoadCustomer |> List.iter (fun x-> printfn "%s" x)

