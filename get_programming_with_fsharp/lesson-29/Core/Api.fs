/// Provides access to the banking API.
module Capstone5.Api

open Capstone5.Domain
open Capstone5.Operations
open System

/// Loads an account from disk. If no account exists, an empty one is automatically created.
let LoadAccount (customer:Customer) : RatedAccount =
   Capstone5.FileRepository.tryFindTransactionsOnDisk customer.Name
   |> Option.map loadAccount
   |> Option.defaultValue (InCredit(CreditAccount { AccountId = Guid.NewGuid(); Balance = 0M; Owner = customer }))

/// Deposits funds into an account.
let Deposit (amount:decimal) (customer:Customer) : RatedAccount =
    let ratedAccount = LoadAccount customer
    let accountId = ratedAccount.GetField (fun a -> a.AccountId)
    let owner = ratedAccount.GetField(fun a -> a.Owner)

    Capstone5.Operations.auditAs
        "deposit"
        Capstone5.Auditing.composedLogger
        Capstone5.Operations.deposit
        amount
        ratedAccount
        accountId
        owner

/// Withdraws funds from an account that is in credit.
let Withdraw (amount:decimal) (customer:Customer) : RatedAccount =
    let ratedAccount = LoadAccount customer

    match ratedAccount with
    | InCredit creditAccount ->
        let (CreditAccount account) = creditAccount
        Capstone5.Operations.auditAs
            "withdraw"
            Capstone5.Auditing.composedLogger
            Capstone5.Operations.withdraw
            amount
            creditAccount
            account.AccountId
            account.Owner
    | Overdrawn -> ratedAccount

/// Loads the transaction history for an owner. If no transactions exist, returns an empty sequence.
let LoadTransactionHistory(customer:Customer) : Transaction seq =
    match Capstone5.FileRepository.tryFindTransactionsOnDisk customer.Name with
    | Some (_, _, trans) -> trans
    | None -> Seq.empty