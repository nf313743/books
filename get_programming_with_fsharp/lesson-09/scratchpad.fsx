let parse (person:string) = 
    let values = person.Split(' ')
    values.[0], values.[1], int(values.[2])

let a, b, c = parse("Mary Asteroids 2500")

printfn "%s" a
printfn "%s" b
printfn "%i" c

let getFilesAndModifiedDates(filePath:string) = 
    let file = System.IO.FileInfo(filePath)
    file.FullName, file.LastWriteTime

let date, isParsed = System.DateTime.TryParse("2012-01-01")

getFilesAndModifiedDates "./scratchpad.fsx"
