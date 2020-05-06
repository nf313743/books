
type Customer = { Balance: int; Name: string }

let handleCustomers customers =
    match customers with
    | [] -> failwith "No customers supplied"
    | [ customer ] -> printfn "Single customer, name is %s" customer.Name
    | [ first; second ] -> printfn "Two customers, balance = %d" (first.Balance + second.Balance)
    | customers -> printfn "Customers supplied: %d" customers.Length


//handleCustomers []
handleCustomers [ { Balance = 100; Name = "Cust01" } ]
handleCustomers [ { Balance = 100; Name = "Cust01" }; { Balance = 100; Name = "Cust02" } ]
handleCustomers [ { Balance = 100; Name = "Cust01" }; { Balance = 100; Name = "Cust02" }; { Balance = 100; Name = "Cust03" } ]


let getStatus customer =
    match customer with
    | { Balance = 0 } -> "Customer has empty balance!"
    | { Name = "Isaac" } -> "This is a great customer!"
    | { Name = name; Balance = 50 } -> sprintf "%s has a large balance!" name
    | { Name = name } -> sprintf "%s is a normal customer" name



{ Balance = 50; Name = "Joe" } |> getStatus

let matchWithinAList customers = 
    match customers with
    | [ { Name = "Tanya" }; { Balance = 25 }; _ ] -> "It's a match!"
    | _ -> "No match!"