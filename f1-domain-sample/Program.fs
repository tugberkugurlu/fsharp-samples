// Learn more about F# at http://fsharp.org

open System
open F1Graph

let getPilotFirstName (x:Pilot) = x.Name.FirstName

[<EntryPoint>]
let main argv =
    let now = NodaTime.Instant.FromDateTimeUtc(DateTime.Now.ToUniversalTime())
    let foo = getPilotFirstName {Id="foo"; Name={FirstName="Fernando"; LastName="Alonso"}}
    printfn "now: %s" (now.ToString())
    printfn "best F1 pilot on the grid: %s" foo
    0 // return an integer exit code