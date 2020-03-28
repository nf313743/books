#load "AutoLoadModule.fs"

let joe =
    { FirstName = "joe"
      LastName = "bloggs"
      Age = 21 }

if joe |> isOlderThan 18 then printfn "%s is an adult" joe.FirstName 
else printfn "%s is a child" joe.FirstName
