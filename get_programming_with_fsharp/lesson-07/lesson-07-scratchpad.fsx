open System

let myUnit = ()

let describeAge age =
    let ageDescription =                 
        if age < 18 then "Child!"        
        elif age < 65 then "Adult!"
        else "OAP!"

    let greeting = "Hello"
    Console.WriteLine("{0}! You are a '{1}'.", greeting, ageDescription)

printfn "Are they equal?: %b" (myUnit = describeAge 5)




let printName =
    let getName =
        printfn "Enter you name:"
        Console.ReadLine()
    let spaceIndex = getName.IndexOf(' ')
    let firstName = getName.Substring(0, spaceIndex)
    printfn "First name: %s" firstName
    