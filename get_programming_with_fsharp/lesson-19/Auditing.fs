module Capstone3.Auditing

open Capstone3.Operations
open Capstone3.Domain
open System

/// Logs to the console
let printTransaction (accountId: Guid) (owner: string) (transaction: Transaction) =
    printfn "Account %O: %s" accountId (Transactions.serialized transaction)

// Logs to both console and file system
let composedLogger =
    let loggers =
        [ FileRepository.writeTransaction
          printTransaction ]

    fun accountId owner message ->
        loggers
        |> List.iter (fun logger -> logger accountId owner message)
