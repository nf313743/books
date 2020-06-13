module Capstone4.Program

open System
open Capstone4.Domain
open Capstone4.Operations

let withdrawWithAudit =
    auditAs "withdraw" Auditing.composedLogger withdrawSafe

let depositWithAudit =
    auditAs "deposit" Auditing.composedLogger deposit

let loadAccountOptional = Option.map Operations.loadAccount

let tryLoadAccountFromDisk =
    FileRepository.tryFindTransactionsOnDisk
    >> loadAccountOptional


[<AutoOpen>]
module CommandParsing =
    let tryParseCommand c =
        match c with
        | 'w' -> Some(AccountCommand Withdraw)
        | 'd' -> Some(AccountCommand Deposit)
        | 'x' -> Some Exit
        | _ -> None


[<AutoOpen>]
module UserInput =
    let commands =
        seq {
            while true do
                Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
                yield Console.ReadKey().KeyChar
                Console.WriteLine()
        }

    let tryGetAmount command =
        Console.WriteLine()
        Console.Write "Enter Amount: "
        let amount = Console.ReadLine() |> Decimal.TryParse
        match amount with
        | true, amount -> Some(command, amount)
        | false, _ -> None


[<EntryPoint>]
let main _ =
    let openingAccount =
        Console.Write "Please enter your name: "
        let owner = Console.ReadLine()

        match (tryLoadAccountFromDisk owner) with
        | Some account -> account
        | None ->
            { Balance = 0m
              AccountId = Guid.NewGuid()
              Owner = { Name = owner } }
            |> classifyAccount

    // printfn "Current balance is £%M" openingAccount.Balance

    let processCommand account (command, amount) =
        printfn ""

        let account =
            match command with
            | Deposit -> account |> depositWithAudit amount
            | Withdraw -> account |> withdrawWithAudit amount


        printfn "Current balance is £%M" (account |> getUnwrapedAccount).Balance
        account

    let closingAccount =
        commands
        |> Seq.choose tryParseCommand
        |> Seq.takeWhile ((<>) Exit)
        |> Seq.choose Operations.tryGetBankOperation
        |> Seq.choose tryGetAmount
        |> Seq.fold processCommand openingAccount

    printfn ""
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0
