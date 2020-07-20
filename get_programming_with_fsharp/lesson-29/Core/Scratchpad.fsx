#r "C:/Users/NFlynn/.nuget/packages/newtonsoft.json/12.0.3/lib/netstandard2.0/Newtonsoft.Json.dll"
#load "Domain.fs"
#load "Operations.fs"
#load "FileRepository.fs"
#load "Auditing.fs"

open Capstone5.Operations
open Capstone5.Domain
open Capstone5.FileRepository
open Capstone5.Auditing
open System

let myPrint x = printf "%A" x

let LoadAccount (customer:Customer) : RatedAccount =
    tryFindTransactionsOnDisk customer.Name
    |> Option.map loadAccount
    |> Option.defaultValue (InCredit(CreditAccount { AccountId = Guid.NewGuid(); Balance = 0M; Owner = customer }))

let LoadTransactionHistory(customer:Customer) : Transaction seq =
    match tryFindTransactionsOnDisk customer.Name with
    | Some (_, _, trans) -> trans
    | None -> Seq.empty

let customer = {Name = "Nathan"}

myPrint (customer |> LoadTransactionHistory)