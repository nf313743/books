module DiscriminatedUnions

type MMCDisk =
    | RsMmc
    | MmcPlus
    | SecureMMC

type Disk =
    | HardDisk of RPM:int * Platters:int
    | SolidState
    | MMC of MMCDisk *  NumberOfPins:int
    

