open System
open System.IO

let myPrint x = printfn "%A" x

type Order =
    { Id: int
      Item: string }

type Customer =
    { CustomerName: string
      Orders: Order list }

let randomNumer =
    let ran = Random()
    fun () -> ran.Next(1, 10)

let generateOrders =
    let createOrder id: Order =
        { Id = id
          Item = "Item #" + id.ToString() }

    let numOfOrders = randomNumer()
    let orders = [ 1 .. numOfOrders ] |> List.map createOrder
    orders

let customers =
    [ 1 .. 10 ]
    |> List.map (fun x-> {CustomerName = "Who Cares"; Orders = generateOrders} )

let allOrders = customers |> List.collect (fun x-> x.Orders)

allOrders |> List.iter(fun x-> myPrint (sprintf "OrderId:%i--Item:%s" x.Id x.Item))

[1..randomNumer()] |> List.pairwise |> List.iter myPrint


allOrders |> List.groupBy (fun x-> x.Item) |> List.iter myPrint
allOrders |> List.countBy (fun x-> x.Item) |> List.iter myPrint
let item3Orders, otherOrders = allOrders |> List.partition (fun x-> x.Item = "Item #3")
item3Orders |> List.iter myPrint




