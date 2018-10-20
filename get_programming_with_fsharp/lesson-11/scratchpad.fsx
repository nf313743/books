open System
open System.IO
open System.IO

let writeToFile (date:DateTime) fileName text =
    let textFileName = sprintf "%s-%s.txt" (date.ToString("yyyyMMdd")) fileName
    System.IO.File.WriteAllText("./" + textFileName, text)


let writeToToday = writeToFile DateTime.UtcNow.Date
let writeToTomorrow = writeToFile (DateTime.UtcNow.Date.AddDays 1.0)
let writeToTodayHelloWorld = writeToToday "hello-world"

writeToToday "first-file" "The quick brown fox jumped over the lazy dog"
writeToTomorrow "second-file" "The quick brown fox jumped over the lazy dog"
writeToTodayHelloWorld "The quick brown fox jumped over the lazy dog"


// Listing 6.7
let drive distance petrol =
    if distance = "far" then petrol / 2.0
    elif distance = "medium" then petrol - 10.0
    else petrol - 1.0

let startPetrol = 100.0

startPetrol
|> drive "far"
|> drive "medium"
|> drive "short"
|> printfn "%f"

let checkCurrentDictionaryAge =
    Directory.GetCurrentDirectory
    >> Directory.GetCreationTime
    


