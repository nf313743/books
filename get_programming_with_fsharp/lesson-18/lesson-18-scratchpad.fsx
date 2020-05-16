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
One the first iteration of the reduce firstRule and secondRule are 'baked' into the `fun word -> ` function.
We'll refer to this as foo`1.  foo`1 is then used in the next iteration.  It is 'baked' firstRule and the secondRule in the list
is 'baked' into second rule. What is returned is foo'2 (which has foo'1 as the firstRule).  As you iterate through the list
the foo'n is 'baked' into the firstRule (apart from the very first iteration where the firstRule is the actual 1st rule from the 
rules list), and secondRule is always the 'real' rule from the next iteration on the list.  The end result is a single rule
with multiple function called embedded /baked into.

On the call to validate the firstRule function is called which will flow down the stack like the following:

foo'3
    => foo'2
        => foo'1
            => "Must be three words" rule

When "Must be three words" rule is return the secondRule is called ("Max length is 30 characters")
foo'3
    => foo'2
        => foo'1
            => "Must be three words" rule -> true
        => secondRule -> "Max length is 30 characters" -> true

The calls will bubble-ups the call stack, and calling secondRule each time it goes up a level.

*)
let buildValidator (rules : Rule list) = 
    rules
    |> List.reduce(fun firstRule secondRule ->
        fun word -> // foo
            let passed, error = firstRule word
            if passed then
                let passed, error = secondRule word
                if passed then true, "" else false, error
            else false, error)

let validate = buildValidator rules
let word = "HELLO FrOM F#"

let result, error = validate word
error|> myPrint
