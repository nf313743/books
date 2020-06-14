
//#r "/home//.nuget/packages/newtonsoft.json/12.0.3/lib/netstandard2.0/Newtonsoft.Json.dll"
//#r "/home//.nuget/packages/humanizer.core/2.8.26/lib/netstandard2.0/Humanizer.dll"
#I "/home//.nuget/packages"
#r "newtonsoft.json/12.0.3/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "humanizer.core/2.8.26/lib/netstandard2.0/Humanizer.dll"
#load "NugetFSharp/Library.fs"


open NugetFSharp.Library1
open Humanizer


let person = getPerson()

"ScriptsAreAGreatWayToExplorePackages".Humanize()
