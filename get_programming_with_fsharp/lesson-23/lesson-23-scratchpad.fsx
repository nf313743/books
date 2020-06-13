type CustomerId = CustomerId of string
type Email = Email of string
type Telephone = Telephone of string
type Address = Address of string

type Customer =
    { CustomerId: CustomerId
      Email: Email
      Telephone: Telephone
      Address: Address }

let createCustomer customerId email telephone address =
    { CustomerId = customerId
      Email = email
      Telephone = telephone
      Address = address }

let customer =
    createCustomer (CustomerId "C-123") (Email "nicki@myemail.com") (Telephone "029-293-23") (Address "1 The Street")


type CustomerDetails =
    | Address of string
    | Telephone of string
    | Email of string

type Customer02 =
    { CustomerId: CustomerId
      PrimaryContactDetails: CustomerDetails
      SecondaryContactDetails: CustomerDetails option }


let createCustomer02 customerId primaryContactDetails secondaryContactDetails =
    { CustomerId = customerId
      PrimaryContactDetails = primaryContactDetails
      SecondaryContactDetails = secondaryContactDetails }

let customerWithAddress =
    createCustomer02 (CustomerId "101") (Address "Gothem") None


type GenuineCustomer = GenuineCustomer of Customer02

let validateCustomer customerArg =
    match customerArg.PrimaryContactDetails with
    | Email e when e.EndsWith "SuperCorp.com" -> Some(GenuineCustomer customerArg)
    | Address _ | Telephone _ -> Some(GenuineCustomer customerArg)
    | Email _ -> None

let sendWelcomeEmail (GenuineCustomer customer) =
    printfn "Hello, %A, and welcome to our site!" customer.CustomerId





printfn "%A" customerWithAddress
