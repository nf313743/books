module Capstone3.Operations

open System
open Capstone3.Domain

/// Withdraws an amount of an account (if there are sufficient funds)
let withdraw amount account =
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount }

/// Deposits an amount into an account
let deposit amount account =
    { account with Balance = account.Balance + amount }

/// Runs some account operation such as withdraw or deposit with auditing.
let auditAs operationName audit operation amount account =
    let audit = audit account.AccountId account.Owner.Name
    let updatedAccount = operation amount account
    let accountIsUnchanged = (updatedAccount = account)
    audit { Timestamp = DateTime.UtcNow; Operation = operationName; Amount = amount; Accepted =accountIsUnchanged }
    updatedAccount


let processTransaction account tansaction =
    match tansaction.Operation with
    | "d" -> {account with Balance = account.Balance + tansaction.Amount }
    | "w" -> {account with Balance = account.Balance - tansaction.Amount}
    | _ -> account

let loadAccount owner accountId (transations: Transaction list) =
    let account = {AccountId = accountId; Owner = owner; Balance = 0M}
    transations
    |> List.sortBy(fun x-> x.Timestamp)
    |> List.fold processTransaction account
