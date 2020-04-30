open System.IO
open System
(*
onvert each string into a full DirectoryInfo object. Use Seq.map to perform the
conversion.
Convert each DirectoryInfo into a tuple of the Name of the folder and its Creation-
TimeUtc , again using Seq.map .
Convert the sequence into a Map of Map.ofSeq .
Convert the values of the Map into their age in days by using Map.map . You can sub-
tract the creation time from the current time to achieve this

*)

let myPrint x = printfn "%A" x


let homeDir =
    System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile)

let t =
    System.IO.Directory.EnumerateDirectories(homeDir)
    |> Seq.map (fun x -> DirectoryInfo(x))
    |> Seq.map (fun x -> (x.Name, x.CreationTimeUtc))
    |> Map.ofSeq
    |> Map.map (fun _ y -> (DateTime.Now - y).Days)
    |> Map.iter (fun x y -> (printfn "%s--%d" x y))



(*Continuing from the previous lesson, create a lookup for all files within a folder so that
you can find the details of any file that has been read. Experiment with sets by identify-
ing file types in folders. What file types are shared between two arbitrary folders?*)

let getFiles dirPath =
    Directory.GetFiles(dirPath) |> List.ofArray

let fileMap =
    System.IO.Directory.EnumerateDirectories(homeDir)
    |> Seq.map (fun x -> DirectoryInfo(x))
    |> Seq.map (fun x -> (x.Name, List.ofArray (x.GetFiles())))
    |> Map.ofSeq

fileMap.["Downloads"]
|> List.iter (fun x -> (myPrint x.Name))

let downloadSet =
    fileMap.["Downloads"]
    |> List.map (fun x -> x.Extension)
    |> Set.ofList

let nathanSet =
    fileMap.["michel-thomas-spanish"]
    |> List.map (fun x -> x.Extension)
    |> Set.ofList

let fileTypesShared = downloadSet |> Set.intersect nathanSet

myPrint fileTypesShared