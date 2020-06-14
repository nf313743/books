#r "CSharpProject/bin/Debug/netstandard2.0/CSharpProject.dll"

open CSharpProject
open System.Collections.Generic

let simon = Person "Simon"
simon.PrintName()

// at 25.3.1
type PersonComparer() =
    interface IComparer<Person> with
        member this.Compare(x, y) = x.Name.CompareTo(y.Name)


let pComparer = PersonComparer() :> IComparer<Person>
pComparer.Compare(simon, Person "Fred")

let pComparer2 =
    { new IComparer<Person> with
        member this.Compare(x, y) = x.Name.CompareTo(y.Name) }


