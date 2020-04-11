open System.Net

let client = new WebClient()

let uri = "site.com/mail.php"

let foo (client:WebClient) (uri:string) (data:string) =
    client.UploadString(uri, data)

let withClient = foo client
let withUri = withClient uri
let result = withUri "myData"


let URI = "http://www.myurl.com/post.php";
let myParameters = "param1=value1&param2=value2&param3=value3";


let clientReadyToPost contentType = 
    let wc = new WebClient()
    wc.Headers.[HttpRequestHeader.ContentType] <- contentType;
    wc

let client02 = clientReadyToPost "application/x-www-form-urlencoded"
client02.UploadString(URI, myParameters)
 