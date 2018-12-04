open System

#load "DiscriminatedUnions.fsx"
open DiscriminatedUnions

let myPrint x = printfn "%A" x

let myHardDisk = HardDisk(RPM=250, Platters = 7)
let myHardDiskShort = HardDisk(250, 7)
let args = 250, 7
let myHardDiskTupled = HardDisk args

let mySolidState = SolidState

let seek disk = 
    match disk with
    | HardDisk(250, _) -> "Seeking very slowly"
    | HardDisk (5400, rpm) -> string rpm
    | HardDisk _-> "Seeking loudly at a reasonable speed."
    | MMC _ -> "Seeking quietly but slowly" 
    | SolidState -> "Already found it"
    

seek myHardDisk
|> myPrint

seek (HardDisk(5400, 66))
|> myPrint

let describe hardDisk =
    match hardDisk with
    | SolidState -> "Im a newfangled SSD."
    | MMC(_, 1) -> "I have only 1 pin."
    | MMC(_, x) when x < 5 -> "I'm a MMC with a few pins."
    | MMC(MmcPlus, 3) -> "Seeking quietly but slowly"
    | MMC(SecureMMC, 6) -> "Seeking quietly with 6 pins"
    | MMC(_, x) -> sprintf "I'm an MMC with %i pins." x
    | HardDisk(5400, _) -> "I'm a slow hard disk."
    | HardDisk(_, 7) -> "I have 7 spindles."
    | HardDisk _ -> "I am  a hard disk."

type DiskInfo = 
    {
        Manufacturer:string
        SizeGb:int
        DiskData:Disk
    }

type Computer = {Manufacturer: string; Disks: DiskInfo list}

let myPc =
    {
        Manufacturer = "Computers Inc."
        Disks = [
            {Manufacturer = "HardDisks Inc."; SizeGb = 100; DiskData = HardDisk(5400, 7)}
            {Manufacturer = "SuperDisks Corp."; SizeGb = 250; DiskData = SolidState}
        ]
    }