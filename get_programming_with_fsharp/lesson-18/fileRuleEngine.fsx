open System.IO
open System

let myPrint x = printfn "%A" x

type Rule = FileInfo -> bool * string

let rules : Rule list =
    [
        fun file -> file.Extension = ".txt", "Should only be text files"
        fun file -> file.Length > 30000L, "File cannot be over 300 bytes"
    ]

let buildRuleValidator (rules: Rule list)=
    rules
    |> List.reduce (fun firstRule secondRule -> 
        fun file -> 
                let passed, error = firstRule file
                if passed then
                    let passed, error = secondRule file
                    if passed then true, "" else false, error
                else 
                    false, error)

let validator = buildRuleValidator rules

let homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)

let files = System.IO.Directory.EnumerateFiles(homeDir, "*", SearchOption.AllDirectories)
            |> Seq.map (fun x -> new FileInfo(x))


files
|> Seq.map(fun x -> x, validator x)
|> Seq.filter(fun (_, ruleResult) -> 
                    let passed, _ = ruleResult 
                    passed)
|> Seq.iter(fun (file, _) -> myPrint file.FullName)