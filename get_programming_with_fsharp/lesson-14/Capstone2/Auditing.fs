module Capstone2.Auditing

open System.IO
open Capstone2.Domain


let ensureDirectoryExists path = Directory.CreateDirectory(path)


let fileSystemAudit account message =
    let dirPath = Path.Combine("./lesson-14/Capstone2", account.Customer.Name)
    let dirInfo = ensureDirectoryExists dirPath
    let filePath = Path.Combine(dirInfo.FullName, (sprintf "%s.txt" (account.Id.ToString())))
    File.AppendAllText(filePath, message)


let consoleAudit account message = printfn "Account %A: %s" account.Id message
