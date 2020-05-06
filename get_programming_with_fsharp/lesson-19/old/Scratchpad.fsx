#load "Domain.fs"
#load "Operations.fs"
#load "FileRepository.fs"

open Capstone3.Operations
open Capstone3.Domain
open Capstone3.FileRepository
open System

let myPrint x = printfn "%A" x
let commands = [ 'd'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w' ]

let isValidCommand x =
    match x with
    | 'w' | 'd' | 'x' -> true
    | _ -> false
 
let isStopCommand x = x = 'x'

let getAmount command = 
    match command with
    | 'd' -> ('d', 50M)
    | 'w' -> ('w', 25M)
    | 'x' -> ('x', 0M)
    | _ -> (command, 0M)

let processCommmand account command =
    match command with
    | 'd', amount -> {account with Balance = account.Balance + amount }
    | 'w', amount -> {account with Balance = account.Balance - amount}
    | _, _ -> account
    
let customer01 = {Name = "Jill"}
let account01 = {AccountId = Guid.Parse("b3106f79-6f72-4345-8df0-52ed06f0055c"); Owner = customer01; Balance = 400M}
let transaction01 = {Timestamp = DateTime.Now; Operation = "d"; Amount=100M; Accepted=true}

writeTransaction account01.AccountId account01.Owner.Name transaction01

snd(findTransactionOnDisk "Jill")
|> Seq.iter (fun x -> x.Amount |> myPrint)
