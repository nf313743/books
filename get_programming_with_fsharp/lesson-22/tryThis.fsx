open System.IO
open System

let myPrint x = printfn "%A" x

type Rule = FileInfo -> bool * string option

let rules : Rule list =
    [
        fun file -> file.Extension = ".txt", Some "Should only be text files"
        fun file -> file.Length > 30000L, Some "File cannot be over 300 bytes"
    ]

let buildRuleValidator (rules: Rule list)=
    rules
    |> List.reduce (fun firstRule secondRule -> 
        fun file -> 
                let passed, error = firstRule file
                if passed then
                    let passed, error = secondRule file
                    if passed then true, None else false, error
                else 
                    false, error)

let validator = buildRuleValidator rules

//let homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
let homeDir = "C:/Users/flynnnat/files"

let files = System.IO.Directory.EnumerateFiles(homeDir, "*", SearchOption.AllDirectories)
            |> Seq.map (fun x -> new FileInfo(x))

let failingPredicate (result, _) = result = false

files
|> Seq.map(fun x -> x, validator x)
|> Seq.filter(fun (_, ruleResult) -> failingPredicate ruleResult)
|> Seq.iter(fun (_, result) ->  snd(result) |> Option.iter myPrint)