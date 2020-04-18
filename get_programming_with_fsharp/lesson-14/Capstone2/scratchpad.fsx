#load "Domain.fs"
#load "Operations.fs"
#load "Auditing.fs"

open System
open System.IO
open Capstone2.Domain
open Capstone2.Operations
open Capstone2.Auditing


let myPrint x = printfn "%A" x


let myAccount =
    { Id = Guid.NewGuid()
      Balance = 5000m
      Customer = { Name = "Frank" } }


fileSystemAudit myAccount "Hello There!"

let tt = sprintf "%s.%s" "myAccount" "txt"