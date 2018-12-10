open System
let myPrint x = printfn "%A" x

type CustomerId = CustomerId of string
type Email = Email of string
type Telephone = Telephone of string
type Address = Address of string

type Customer = { 
        CustomerId : CustomerId
        Email : Email
        Telephone : Telephone
        Address : Address 
    }

let createCustomer customerId email telephone address =
    {
        CustomerId = customerId
        Email = email 
        Telephone = telephone
        Address = address
    }

let customer =
    createCustomer (CustomerId null) (Email "nicki@myemail.com") (Telephone "029-293-23") (Address "1 The Street")

type ContactDetails =
    | Address of string
    | Telephone of string
    | Email of string


type Customer2 = { 
        CustomerId : CustomerId
        PrimaryContactDetails : ContactDetails
        SecondaryContactDetails: ContactDetails option
    }
let createCustomer2 customerId primaryContactDetails secondaryContactDetails=
    {
        CustomerId = customerId
        PrimaryContactDetails = primaryContactDetails
        SecondaryContactDetails = secondaryContactDetails
    }

let customer2 =
    createCustomer2 (CustomerId null) (Address "1 The Street") None

type GenuineCustomer = GenuineCustomer of Customer2

let validateCustomer customer =
    match customer.PrimaryContactDetails with
    | Email x when x.EndsWith "gmail.com" -> Some (GenuineCustomer customer)
    | Address _ | Telephone  _ -> Some (GenuineCustomer customer)
    | Email _ -> None


type Result<'a> =
    | Success of 'a
    | Failure of string

let insertCustomer contactDeails =
    match contactDeails with
    | Email x when x.Contains("@") -> Success 9000
    | Address _  | Telephone _ -> Success 9000
    | Email _ -> Failure "Invalid email"

match insertCustomer (Email "sdfs@dasdf") with
| Success x -> x |> myPrint
| Failure x -> x |> myPrint

