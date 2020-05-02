open System


let myPrint x = printfn "%A" x

let max inputs =
    List.fold (fun state input -> if input > state then input else state) 0 inputs

let length inputs =
    List.fold (fun state _ -> state + 1) 0 inputs



// [1;2;33;4;5;6;7] |> max |> myPrint
// [1;2;33;4;5;6;7] |> length |> myPrint
// [5;457;65734;2;5] |> List.reduce (fun state _ -> state + 1) |> myPrint
(0,[5;457;65734;2;5]) ||> List.fold (fun state _ -> state + 1) |> myPrint


type Rule = string -> bool * string

let rules : Rule list = 
    [ 
        fun text -> 
            printfn "Running 3 word rule"
            (text.Split ' ').Length = 3, "Must be three words"
        fun text -> 
            printfn "Running max length rule"
            text.Length <= 30, "Max length is 30 characters"
        fun text -> 
            printfn "Running all caps rules"
            text |> Seq.filter Char.IsLetter |> Seq.forall Char.IsUpper, "All letters must be caps"
    ]



let buildValidator (rules : Rule list) =
    rules
    |> List.reduce (fun firstRule secondRule ->
        fun word ->
            let passed, error = firstRule word
            if passed then
                let passed, error = secondRule word
                if passed then true, "" else false, error
            else false , error)

let validate = buildValidator rules
let word = "hello 555 hrth"
let result, error = validate word 

printfn "Error: %s" error 