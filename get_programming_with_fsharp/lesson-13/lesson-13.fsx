open System.Net
open System

let client = new WebClient()

let uri = "site.com/mail.php"

let foo (client:WebClient) (uri:string) (data:string) =
    client.UploadString(uri, data)

let withClient = foo client
let withUri = withClient uri
let result = withUri "myData"
