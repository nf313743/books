open System
let getRandom =
    let random = Random()
    fun () -> random.Next(1, 10)

let listOfNums = [for _ in 1 .. getRandom() -> getRandom()]

match listOfNums with
| [] -> printfn "List is empty"
| _ when listOfNums.Length = 9 -> printfn "List is 10 in length"
| head::_ when head = 5 -> printfn "First item is 5"
| _ ->
    printf "No matches.  Length: %i -- " listOfNums.Length
    listOfNums |> List.iter (fun x-> printf "%i " x)
