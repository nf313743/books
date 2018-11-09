namespace Capstone2.Domain
open System

type Customer = 
    {
        Name:string
    }

type Account =
    {
        Id:Guid
        Balance:decimal
        Customer:Customer
    }
