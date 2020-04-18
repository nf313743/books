open System
open System.IO

let writeToFile (date: DateTime) filename text =
    let fileName = date.ToString("yyyy-MM-dd") + "--" + filename + ".txt"
    System.IO.File.WriteAllText("./" + fileName, text)


let writeToToday = writeToFile DateTime.UtcNow.Date
let writeToTomorrow = writeToFile (DateTime.UtcNow.Date.AddDays 1.)
let writeToTodayHelloWorld = writeToToday "hello-world"

writeToToday "first-file" "The quick brown fox jumped over the lazy dog"
writeToTomorrow "second-file" "The quick brown fox jumped over the lazy dog"
writeToTodayHelloWorld "The quick brown fox jumped over the lazy dog"



let drive distance petrol =
    if distance = "far" then petrol / 2.0
    elif distance = "medium" then petrol - 10.0
    else petrol - 1.0

let startPetrol = 100.0

let result =
    startPetrol
    |> drive "far"
    |> drive "medium"
    |> drive "short"

let checkCreation (date: DateTime) =
    match date.Year with
    | x when x < 2018 -> "old"
    | _ -> "not old"

// Compose into a single function as the inputs and outputs match
let checkCurrentDirectoryAge =
    Directory.GetCurrentDirectory
    >> Directory.GetCreationTime
    >> checkCreation

let description = checkCurrentDirectoryAge()
