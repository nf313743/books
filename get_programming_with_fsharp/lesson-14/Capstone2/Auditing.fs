module Capstone2.Auditing
open Capstone2.Domain

let fileSystemAudit account message =
    ()
let consoleAudit account message =
    printfn "Account %A: %s" account.Id message