let getFileDetails filePath =
    let file = System.IO.FileInfo(filePath)
    file.Name, file.LastWriteTime

let fileName, lastModified = getFileDetails "./test.txt"

printfn "Filename: %s" fileName
printfn "Last Modified: %s" (lastModified.ToString())