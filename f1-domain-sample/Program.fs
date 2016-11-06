// Learn more about F# at http://fsharp.org

open System
open F1Graph

let getPilotFirstName (x:Pilot) = x.Name.FirstName

[<EntryPoint>]
let main argv =
    let now = NodaTime.Instant.FromDateTimeUtc(DateTime.Now.ToUniversalTime())
    let fernandoAlonso = Pilot.create "Fernando" "Alonso"
    let pilotFirstName = getPilotFirstName fernandoAlonso
    let newPilot = { fernandoAlonso with Name={ fernandoAlonso.Name with FirstName="Lewis" } }
    printfn "now: %s" (now.ToString())
    printfn "best F1 pilot on the grid: %s" pilotFirstName
    printfn "best F1 pilot on the grid with new first name: %s" (getPilotFirstName newPilot)
    0 // return an integer exit code