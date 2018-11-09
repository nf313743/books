let myPrint x = printfn "%A" x

type Customer = 
    {
        Name:string
    }

type Account =
    {
        Id:int
        Balance:decimal
        Customer:Customer
    }


let deposit amount account =
    let accountWithNewBalance = {account with Balance = account.Balance + amount}
    accountWithNewBalance

let withdraw amount account =
    match amount > account.Balance with
    | true -> account
    | false -> {account with Balance = account.Balance - amount}


let cust = {Name="Nathan"}
let acc = {Id = 1; Balance = 2000M; Customer = cust}
let fileSystemAudit account message =
    ()
let consoleAudit account message =
    printfn "Account %A: %s" account.Id message

let auditAs operationName audit operation amount account =
    let auditWithAccount = audit account
    auditWithAccount (sprintf "%s £%M" operationName amount)
    let updatedAccount = operation amount account
    
    if updatedAccount.Balance <> account.Balance then auditWithAccount (sprintf "Transaction Successful. New balance:%M" updatedAccount.Balance)
    else auditWithAccount "Transaction Failed"

    updatedAccount

let withdrawWithConsoleAudit = auditAs "withdraw" consoleAudit withdraw
let depositWithConsoleAudit = auditAs "deposit" consoleAudit deposit

acc
|> withdrawWithConsoleAudit 100000M
|> depositWithConsoleAudit 400M