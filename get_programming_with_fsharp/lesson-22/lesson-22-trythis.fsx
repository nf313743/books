open System.IO
open System
(*
Create a simple rules engine over the filesystem example from the previous lesson. The
engine should filter out files that don’t pass certain checks, such as being over a specific
file size, having a certain extension, or being created before a specific date. Have you
ever created any rules engines before? Try rewriting them in the style we defined in this
lesson.
*)

let myPrint x = printfn "%A" x

type Rule = FileInfo -> bool * string option

let homeDir =
    System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile)

let downloadDir = Path.Combine(homeDir, "Downloads")

    
let getFiles dir = 
    System.IO.Directory.EnumerateFiles(dir, "*", System.IO.SearchOption.AllDirectories)
    |> Seq.map (fun x -> FileInfo(x))


let rules: Rule list = 
    [fun (x:FileInfo) -> x.Extension = ".pdf", Some("Extension must be pdf")
     fun x-> (DateTime.Now - x.CreationTimeUtc).Days <= 30, Some("Must be 30 days or newer")]

let buildValidator (rules : Rule list) = 
    rules
    |> List.reduce(fun firstRule secondRule ->
        fun word ->
            let passed, error = firstRule word
            if passed then
                let passed, error = secondRule word
                if passed then true, None else false, error
            else false, error)

let validate = buildValidator rules


let results = 
    downloadDir
    |> getFiles
    |> Seq.filter(validate >> fst)



results |> Seq.map(fun x-> x.FullName) |> Seq.iter myPrint