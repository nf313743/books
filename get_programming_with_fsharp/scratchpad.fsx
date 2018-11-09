open System
let myPrint x = printfn "%A" x

type Customer = {Age:int}
let whereFilter = 
    

    
    let where filter customers = 
        seq {
            for customer in customers do
                if filter customer then
                    yield customer
        }

    let customers = [{Age=21};{Age=35}; {Age= 36}]
    let isOver35 customer = customer.Age > 35
    customers |> where isOver35 |> myPrint
    customers |> where (fun customer -> customer.Age > 34) |> myPrint

let printCustomerAge writer customer =
    if customer.Age < 13 then writer "Child!"
    elif customer.Age < 20 then writer "Teenager!"
    else writer "Adult!"

printCustomerAge Console.WriteLine {Age =21}

let printToConsole = printCustomerAge Console.WriteLine
printToConsole {Age = 12}

open System.IO

let writeToFile text = File.WriteAllText("./output.txt", text)
let printToFile = printCustomerAge writeToFile
printToFile {Age = 21}