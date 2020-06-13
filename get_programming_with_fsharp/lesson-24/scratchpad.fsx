#load "Domain.fs"
#load "Operations.fs"

open Capstone4.Operations
open Capstone4.Domain
open System

type BankCommand = Deposit | Withdraw

type Command =
    |AccountCommand of BankCommand
    | Exit

let tryGetBankOPeration cmd =
    match cmd with
    | Exit -> None
    | AccountCommand op -> Some op










