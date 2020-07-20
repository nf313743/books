namespace Capstone5.Domain

open System

type BankOperation = Deposit | Withdraw
type Customer = { Name : string }
type Account = { AccountId : Guid; Owner : Customer; Balance : decimal }
type Transaction = { Timestamp : DateTime; Operation : string; Amount : decimal }

/// Represents a bank account that is known to be in credit.
type CreditAccount = CreditAccount of Account

/// A bank account which can either be in credit or overdrawn.
type RatedAccount =
    | InCredit of CreditAccount
    | Overdrawn of Account
    member this.GetField getter =
        match this with
        | InCredit (CreditAccount account) -> getter account
        | Overdrawn account -> getter account

    member this.Balance =
        match this with
        | InCredit (CreditAccount account) -> account.Balance
        | Overdrawn account -> account.Balance

module Transactions =
    /// Serializes a transaction
    let serialize transaction =
        Newtonsoft.Json.JsonConvert.SerializeObject(transaction)

    /// Deserializes a transaction
    let deserialize (fileContents:string) =
        Newtonsoft.Json.JsonConvert.DeserializeObject<Transaction>(fileContents)