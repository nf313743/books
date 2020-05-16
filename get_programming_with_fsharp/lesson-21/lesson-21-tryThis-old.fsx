open System.IO
open System

let myPrint x = printfn "%A" x

type Result =
    | Pass
    | Fail of string

type Rule = FileInfo -> Result



let rules : Rule list =
    [
        fun file -> 
                    match file.Extension with
                    | ".txt" -> Pass
                    | _  -> Fail("Should only be text files")
        fun file -> 
                    match file.Length with
                    | x when x > 30000L -> Pass
                    | _ -> Fail("File cannot be less than 300 bytes")
    ]

let buildRuleValidator (rules: Rule list)=
    rules
    |> List.reduce (fun firstRule secondRule -> 
        fun file -> 
                let result = firstRule file
                match result with
                | Pass -> secondRule file
                | Fail(_) -> result)


let validator = buildRuleValidator rules

//let homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
let homeDir = "C:/Users/flynnnat/files"

let files = System.IO.Directory.EnumerateFiles(homeDir, "*", SearchOption.AllDirectories)
            |> Seq.map (fun x -> new FileInfo(x))


let passingPredicate result = 
    match result with
    | Pass -> true
    | Fail(_) -> false

let failingPredicate result = 
    match result with
    | Pass -> false
    | Fail(_) -> true

files
|> Seq.map(fun x -> x, validator x)
|> Seq.filter(fun (_, ruleResult) -> passingPredicate ruleResult)
|> Seq.iter(fun (file, _) -> myPrint file.FullName)

files
|> Seq.map(fun x -> x, validator x)
|> Seq.filter(fun (_, ruleResult) -> failingPredicate ruleResult)
|> Seq.iter(fun (_, error) -> 
                    match error with 
                    | Fail(msg) -> myPrint msg
                    | Pass -> myPrint "")
