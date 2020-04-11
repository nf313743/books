type Customer = { Age : int }

let where filter customers =
    seq {
    for customer in customers do
        if filter customer then
            yield customer }


let customers = [ { Age = 21 }; { Age = 35 }; { Age = 36 } ]
let isOver35 customer = customer.Age > 35
customers |> where isOver35
customers |> where (fun customer -> customer.Age > 35)

let printCustomerAge writer (customer:Customer) =
    match customer.Age with
    | x when x >= 18 -> writer "Adult"
    | x when x >= 13 -> writer "Teenager"
    | _ -> writer "Child"
   
let printToConsole = printCustomerAge System.Console.WriteLine

let writeToFile text = System.IO.File.WriteAllText("./out.txt", text)
let printToFile = printCustomerAge writeToFile
