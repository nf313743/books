module Capstone3.Program

open System
open Capstone3.Domain
open Capstone3.Operations

let isValidCommand (command: char) =
    match command with
    | 'w'
    | 'd'
    | 'x' -> true
    | _ -> false

let isStopCommand (command: char) = command = 'x'

let getAmountConsole (command: char) =
    Console.Write "\nEnter Amount: "
    let amount = Decimal.Parse(Console.ReadLine())
    (command, amount)


let withdrawWithAudit =
    auditAs "withdraw" Auditing.composedLogger withdraw

let depositWithAudit =
    auditAs "deposit" Auditing.composedLogger deposit


let processCommand (account: Account) (command: char, amount: decimal) =
    match command with
    | 'd' -> depositWithAudit amount account
    | 'w' -> withdrawWithAudit amount account
    | _ -> account


let consoleCommands =
    seq {
        while true do
            Console.Write "\n(d)eposit, (w)ithdraw or e(x)it: "
            yield Console.ReadKey().KeyChar
    }

[<EntryPoint>]
let main _ =
    let name =
        Console.Write "Please enter your name: "
        Console.ReadLine()

    let openingAccount =
        let accountId, transactions =
            FileRepository.findTransactionsOnDisk name

        loadAccount name accountId transactions

    let closingAccount =
        consoleCommands
        |> Seq.filter isValidCommand
        |> Seq.takeWhile (not << isStopCommand)
        |> Seq.map getAmountConsole
        |> Seq.fold processCommand openingAccount


    Console.Clear()
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0
