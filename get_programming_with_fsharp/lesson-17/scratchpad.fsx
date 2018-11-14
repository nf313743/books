open System
open System.IO

System.IO.Directory.EnumerateDirectories("/home/nathan")
|> Seq.map (fun x -> new DirectoryInfo(x))
|> Seq.map (fun x -> x.Name, x.CreationTimeUtc)
|> Map.ofSeq
|> Map.map (fun x y-> (DateTime.Now - y).Days)
|> Map.iter (fun x y -> printfn "Dir:%s - Age:%i" x y)