module Capstone2.Operations
open Capstone2.Domain

let deposit amount account =
    let accountWithNewBalance = {account with Balance = account.Balance + amount}
    accountWithNewBalance

let withdraw amount account =
    match amount > account.Balance with
    | true -> account
    | false -> {account with Balance = account.Balance - amount}


let auditAs operationName audit operation amount account =
    let auditWithAccount = audit account
    auditWithAccount (sprintf "%s £%M" operationName amount)
    let updatedAccount = operation amount account
    
    if updatedAccount.Balance <> account.Balance then auditWithAccount (sprintf "Transaction Successful. New balance:%M" updatedAccount.Balance)
    else auditWithAccount "Transaction Failed"

    updatedAccount