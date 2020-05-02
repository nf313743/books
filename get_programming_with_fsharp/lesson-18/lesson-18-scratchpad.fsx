open System
let myPrint x = printfn "%A" x

let myNumbers = [1;2;3;4;5;6;56;7;8;9]

let sum inputs =
    let mutable accumulator = 0

    for input in inputs do
        accumulator <- accumulator + input
    accumulator

let length inputs =
    let mutable accumulator = 0

    for _ in inputs do
        accumulator <- accumulator + 1
    accumulator

let max inputs =
    let mutable max = 0

    for input in inputs do
        if input > max then max <- input
    max



let sumFold inputs =
    Seq.fold (fun state input -> 
            let newState = state + input
            printfn "Current state is %d, input is %d, new state value is %d" state input newState
            newState) 
        0 
        inputs
    
let lengthFold inputs =
    Seq.fold(fun state _ -> state + 1) 0 inputs

let maxFold inputs =
    let getMax a b = 
        match a > b with
        | true -> a
        | false -> b
    Seq.fold(getMax) 0 inputs


myNumbers |> sumFold |>  myPrint
(0, myNumbers) ||> Seq.fold((+))


type Rule = string -> bool * string

let rules: Rule list =
    [fun text -> (text.Split ' ').Length = 3, "Must be three words"
     fun text -> text.Length <= 30, "Max length is 30 characters"
     fun text -> text
                |> Seq.filter Char.IsLetter
                |> Seq.forall Char.IsUpper, "All letters must be caps" ]




(*
  Let's assume the firstRule fails. What is retured is a function: word -> (false, "Must be three words")
  This is 'returned' to be used as the next first rule in the reduce. Because it was will
  return false (along with the original error) when provided ANY string, it acts as 
  a short circuit and secondRule is never evaluated.

Let's assume the firstRule passed. The second rule is then evaluated.  If that fails then you have the same
situation as the first rule failing: return a function word -> (false, error) - which will now act as the short
-circuit.  However, if secondRule pass it return a function that always returns for any word: word -> (true, "").myPrint
This is then used as the firstRule in the nextIteration and acts as an 'opposite short-circuit' (awalys returning true)
so that the secondRule in the list iteration is evaluated.
*)
let buildValidator (rules : Rule list) = 
    rules
    |> List.reduce(fun firstRule secondRule ->
        fun word ->
            let passed, error = firstRule word
            if passed then
                let passed, error = secondRule word
                if passed then true, "" else false, error
            else false, error)

let validate = buildValidator rules
let word = "HELLO FrOM F#"

let result, error = validate word
error|> myPrint
