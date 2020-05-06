namespace Capstone3.Domain

open System

type Customer = { Name: string }

type Account =
    { AccountId: Guid
      Owner: Customer
      Balance: decimal }

type Transaction =
    { Timestamp: DateTime
      Operation: string
      Amount: decimal
      IsAccepted: bool }



module Transactions =
    let serialized transaction =
        sprintf "%O***%s***%M***%b" transaction.Timestamp transaction.Operation transaction.Amount transaction.IsAccepted


    let deserialize (message: string) =
        let splitString = message.Split("***")
        { Timestamp = DateTime.Parse(splitString.[0])
          Operation = splitString.[1]
          Amount = Decimal.Parse(splitString.[2])
          IsAccepted = bool.Parse(splitString.[3]) }
