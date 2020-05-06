module Capstone3.Operations

open System
open Capstone3.Domain

/// Withdraws an amount of an account (if there are sufficient funds)
let withdraw amount account =
    if amount > account.Balance then
        account
    else
        { account with
              Balance = account.Balance - amount }

/// Deposits an amount into an account
let deposit amount account =
    { account with
          Balance = account.Balance + amount }

/// Runs some account operation such as withdraw or deposit with auditing.
let auditAs operationName audit operation amount account =
    let audit =
        audit account.AccountId account.Owner.Name

    let updatedAccount = operation amount account
    let accountIsUnchanged = (updatedAccount = account)

    let transaction =
        { Timestamp = DateTime.UtcNow
          Operation = operationName
          Amount = amount
          IsAccepted = not accountIsUnchanged }

    audit transaction
    updatedAccount

let loadAccount owner accountId transactions =
    let startAccount =
        { AccountId = accountId
          Owner = { Name = owner }
          Balance = 0m }

    let performOp account transaction =
        match transaction.Operation with
        | "withdraw" -> withdraw transaction.Amount account
        | _ -> deposit transaction.Amount account

    transactions
    |> Seq.sortBy (fun x -> x.Timestamp)
    |> Seq.fold (fun state next -> (performOp state next)) startAccount
