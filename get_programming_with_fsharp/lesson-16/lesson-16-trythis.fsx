open System.IO


// Write a simple script that, given a folder path on the local filesystem,
// will return the name and size of each subfolder within it.
// Use groupBy to group files by folder, before using an aggregation function such as sumBy to total the size of files in each folder.
// Then, sort the results by descending size. Enhance the script to return a proper F# record that contains the folder name, size,
// number of files, average file size, and the distinct set of file extensions within the folder.

type MyFolderInfo =
    { Name: string
      Size: int64
      AverageFileSize: float
      FileExtensions: Set<string> }


let homeDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile)
let downloadDir = System.IO.Path.Combine(homeDir, "Downloads")

let toMegaBytes (bytes: float) = (bytes / 1024.0 / 1024.0).ToString() + "MB"

let getFileExtensionSet (files: FileInfo array) =
    files
    |> Array.map (fun x -> x.Extension)
    |> Set.ofArray

let getAverageSize (files: FileInfo array) = files |> Array.averageBy (fun x -> (float x.Length))

let mapToFolderInfo (files: FileInfo array) =
    let averageSize = files |> Array.averageBy (fun x -> (float x.Length))
    let totalSize = files |> Array.sumBy (fun x -> x.Length)
    let dirName = (Array.head files).DirectoryName
    let extensions = files |> getFileExtensionSet
    { Name = dirName
      Size = totalSize
      AverageFileSize = averageSize
      FileExtensions = extensions }

let myPrint (folderInfo: MyFolderInfo) =
    printfn "Folder Name:  %s" folderInfo.Name
    printfn "Size:  %s" (toMegaBytes (float folderInfo.Size))
    printfn "Average Size:  %s" (toMegaBytes folderInfo.AverageFileSize)
    printf "Extensions:"
    folderInfo.FileExtensions |> Seq.iter (fun x -> printf "%s | " x)
    printfn ""
    printfn ""



System.IO.Directory.GetDirectories(downloadDir, "*", System.IO.SearchOption.AllDirectories)
|> Array.collect (fun x -> Directory.GetFiles(x))
|> Array.map (fun x -> FileInfo(x))
|> Array.groupBy (fun x -> x.DirectoryName)
|> Array.map (fun (_, y) -> mapToFolderInfo y)
|> Array.sortByDescending (fun x -> x.Size)
|> Array.truncate 3
|> Array.iter myPrint
