module Capstone3.FileRepository

open Capstone3.Domain
open System.IO
open System
open Capstone3.Domain.Transactions
open Capstone3.Domain

let private accountsPath =
    let path = @"accounts"
    Directory.CreateDirectory path |> ignore
    path
let private findAccountFolder owner =    
    let folders = Directory.EnumerateDirectories(accountsPath, sprintf "%s_*" owner)
    if Seq.isEmpty folders then ""
    else
        let folder = Seq.head folders
        DirectoryInfo(folder).Name
let private buildPath(owner, accountId:Guid) = sprintf @"%s/%s_%O" accountsPath owner accountId

/// Logs to the file system
let writeTransaction accountId owner transaction =
    let path = buildPath(owner, accountId)    
    path |> Directory.CreateDirectory |> ignore
    let filePath = sprintf "%s/%d.txt" path (DateTime.UtcNow.ToFileTimeUtc())
    File.WriteAllText(filePath, (serialize transaction))

let findTransactionOnDisk owner : (Guid * seq<Transaction>) =
    let accountDir = findAccountFolder owner
    match accountDir with
    | "" -> (Guid.NewGuid(), Seq.empty)
    | _ -> 
        let accountId = accountDir.Substring(accountDir.IndexOf("_") + 1) |> Guid.Parse
        let path = buildPath(owner, accountId)
        Directory.EnumerateFiles(path)
        |> Seq.map File.ReadAllText
        |> Seq.map deserialize
        |> (fun x -> (accountId, x))



