open System
open Capstone2.Domain
open Capstone2.Operations
open Capstone2.Auditing

[<EntryPoint>]
let main argv =
    printfn "Enter Name:"
    let name = Console.ReadLine()

    let mutable account = {Id = Guid.NewGuid(); Balance = 1000M; Customer = {Name = name}}

    let withdrawWithAudit = auditAs "withdraw" consoleAudit withdraw
    let depositWithAudit = auditAs "deposit" consoleAudit deposit

    while true do
        printfn "Enter operation:"
        let operation = Console.ReadLine()
        
        if operation = "x" then Environment.Exit 0

        printfn "Enter amount:"
        let amount = Decimal.Parse(Console.ReadLine())

        account <- 
            if operation = "d" then account |> depositWithAudit amount
            elif operation = "w" then account |> withdrawWithAudit amount
            else account
       
    0 
