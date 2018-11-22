open System
type Rule = string -> bool * string
let rules : Rule list =
    [ fun text -> 
            printfn "Running rule 1"
            (text.Split ' ').Length = 3, "Must be three words"

      fun text -> 
             printfn "Running rule 2"
             text.Length <= 30, "Max length is 30 characters"
      fun text -> 
                printfn "Running rule 3"
                text
                |>Seq.filter Char.IsLetter
                |> Seq.forall Char.IsUpper, "All letters must be caps" 
      fun text -> 
                printfn "Running rule 4"
                text.Length > 42, "Here we are" 
                                                ]
let mutable counter = 0
let buildValidator (rules : Rule list) =
    rules
    |> List.reduce(fun firstRule secondRule ->
        fun word ->
            printfn "firstRule-enter"
            let passed, error = firstRule word
            printfn "firstRule-exit"
            if passed then
                printfn "secondRule-enter"
                let passed, error = secondRule word
                printfn "secondRule-exit"
                if passed then true, "" else false, error
            else 
                counter <- counter + 1
                printfn "%i" counter
                printfn "Fail"
                false, error)

let validate = buildValidator rules
let word = "HELLO EEEEEEE EEEEEE"
//let word = "HELLO HELLO"
let result, msg = validate word
