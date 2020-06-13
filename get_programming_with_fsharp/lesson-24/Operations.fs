module Capstone4.Operations

open System
open Capstone4.Domain

let getUnwrapedAccount account =
    match account with
    | InCredit (CreditAccount account) -> account
    | Overdrawn account -> account

let classifyAccount account =
    match account.Balance >= 0M with
    | true -> InCredit(CreditAccount account)
    | false -> Overdrawn account

let withdraw amount (CreditAccount account) =
    { account with
          Balance = account.Balance - amount }
    |> classifyAccount

let withdrawSafe amount ratedAccount =
    match ratedAccount with
    | InCredit account -> account |> withdraw amount
    | Overdrawn _ ->
        printfn "Your account is overdrawn - withdrawal rejected!"
        ratedAccount

let deposit amount account =
    let account =
        match account with
        | InCredit (CreditAccount account) -> account
        | Overdrawn account -> account

    { account with
          Balance = account.Balance + amount }
    |> classifyAccount


/// Runs some account operation such as withdraw or deposit with auditing.
let auditAs operationName audit operation amount (account: RatedAccount) =
    let updatedAccount = operation amount account

    let transaction =
        { Operation = operationName
          Amount = amount
          Timestamp = DateTime.UtcNow }

    let accountUnwraped = account |> getUnwrapedAccount

    audit accountUnwraped.AccountId accountUnwraped.Owner.Name transaction
    updatedAccount

/// Creates an account from a historical set of transactions
let loadAccount (owner, accountId, transactions) =
    let openingAccount =
        { AccountId = accountId
          Balance = 0M
          Owner = { Name = owner } }
        |> classifyAccount

    transactions
    |> Seq.sortBy (fun txn -> txn.Timestamp)
    |> Seq.fold (fun account txn ->
        match txn.Operation with
        | "deposit" -> (deposit txn.Amount account)
        | "withdraw" -> (withdrawSafe txn.Amount account)
        | _ -> raise (Exception("Invalid operation in file"))) openingAccount



let tryGetBankOperation cmd =
    match cmd with
    | Exit -> None
    | AccountCommand op -> Some op
