open System.IO
open System

let myPrint x = printfn "%A" x

type Result =
    | Pass
    | Fail of Error:string

type Rule = FileInfo -> Result

let homeDir =
    System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile)

let downloadDir = Path.Combine(homeDir, "Downloads")

    
let getFiles dir = 
    System.IO.Directory.EnumerateFiles(dir, "*", System.IO.SearchOption.AllDirectories)
    |> Seq.map (fun x -> FileInfo(x))


let rules: Rule list = 
    [fun (x:FileInfo) -> 
        match x.Extension = ".pdf" with
        | true -> Pass 
        | false ->  Fail("Extension must be pdf")
     fun x-> 
        match(DateTime.Now - x.CreationTimeUtc).Days <= 200 with
        | true -> Pass
        | false -> Fail( "Must be 30 days or newer")]


let buildValidator (rules : Rule list) = 
    rules
    |> List.reduce(fun firstRule secondRule ->
        fun word -> 
            match firstRule word with
            | Pass -> secondRule word 
            | Fail(error) -> Fail(error))


let validate = buildValidator rules


let results = 
    downloadDir
    |> getFiles
    |> Seq.filter(fun x-> 
        match validate x with
        | Pass -> true
        | Fail _ -> false)



results |> Seq.map(fun x-> x.FullName) |> Seq.iter myPrint