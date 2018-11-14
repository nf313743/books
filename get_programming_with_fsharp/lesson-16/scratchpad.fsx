open System.IO

type MyDirInfo =
    {
        Name:string
        Size: int64
        NumberOfFiles: int
        AverageSize:int64
        DistinctExtensions: string[]
    }


let directory = "C:/_dev/nathan/books/get_programming_with_fsharp"

let dirInfo = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories)
                |> Array.map (fun x-> (x, Directory.GetFiles(x)
                                |> Array.map (fun y -> new FileInfo(y))))

let distinctExt (files:FileInfo[]) =
    files
    |> Array.map (fun x -> x.Extension)
    |> Array.distinct

dirInfo
|> Array.map (fun (x,y) -> 
                {
                    Name = x
                    Size = y |> Array.sumBy(fun a -> a.Length)
                    NumberOfFiles = y |> Array.length
                    AverageSize = 0L // y |> Array.averageBy (fun a -> a.Length)
                    DistinctExtensions = y |> distinctExt
                })
 |> Array.iter (fun x -> printf "%A" x)

  