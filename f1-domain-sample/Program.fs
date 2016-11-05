// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv = 
    let now = NodaTime.Instant.FromDateTimeUtc(DateTime.Now.ToUniversalTime())
    printfn "now: %s" (now.ToString())
    0 // return an integer exit code