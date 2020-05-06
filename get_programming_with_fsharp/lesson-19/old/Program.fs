module Capstone3.Program

open System
open Capstone3.Domain
open Capstone3.Operations
open Capstone3.FileRepository

let commands = [ 'd'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w' ]

let printNewLine = Console.WriteLine ""
let isValidCommand x =
    match x with
    | 'w' | 'd' | 'x' -> true
    | _ -> false
 
let isStopCommand x = x = 'x'

let getAmountConsole command = 
    Console.WriteLine ""
    Console.Write "How much: "
    let amount = Console.ReadLine() |> decimal
    match command with
    | 'd' -> ('d', amount)
    | 'w' -> ('w', amount)
    | 'x' -> ('x', amount)
    | _ -> (command, 0M)

let withdrawWithAudit = auditAs "w" Auditing.composedLogger withdraw
let depositWithAudit = auditAs "d" Auditing.composedLogger deposit

let processCommmand account command =
    match command with
    | 'd', amount -> depositWithAudit amount account
    | 'w', amount -> withdrawWithAudit amount account
    | _, _ -> account
    
[<EntryPoint>]
let main _ =
    let name =
        Console.Write "Please enter your name: "
        Console.ReadLine()

    let customer = {Name = name}
   
    let getOpeningAccount customer =
        let guid, transactions = findTransactionOnDisk customer.Name    
        match (Seq.isEmpty transactions) with
        | true -> { Owner = customer; Balance = 0M; AccountId = guid }
        | false -> 
                printfn "Loading account"
                printfn "%i" (Seq.length transactions)
                loadAccount customer guid (List.ofSeq transactions)
   
    let openingAccount = getOpeningAccount customer

    let consoleCommands = seq {
        while true do
            printNewLine
            Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
            yield Console.ReadKey().KeyChar
    }

    let closingAccount =
        consoleCommands
        |> Seq.filter isValidCommand
        |> Seq.takeWhile(not << isStopCommand)
        |> Seq.map getAmountConsole
        |> Seq.fold processCommmand openingAccount
        
    Console.Clear()
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore
    0