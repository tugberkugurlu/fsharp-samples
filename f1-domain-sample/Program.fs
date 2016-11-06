// Learn more about F# at http://fsharp.org

open System
open F1Graph

let getPilotFirstName (x:Pilot) = x.Name.FirstName 

let getNumberAndLog =
    printfn "getNumberAndLog for the first time"
    let random = System.Random()

    fun x ->
        let num = random.Next()
        printfn "getting num: %i" num
        num + x

let getNumbers =
    seq { for i in 1 .. 10 do 
            yield getNumberAndLog i 
        }

[<EntryPoint>]
let main argv =
    let now = NodaTime.Instant.FromDateTimeUtc(DateTime.Now.ToUniversalTime())
    let fernandoAlonso = Pilot.create "Fernando" "Alonso"
    let pilotFirstName = getPilotFirstName fernandoAlonso
    let newPilot = { fernandoAlonso with Name={ fernandoAlonso.Name with FirstName="Lewis" } }

    printfn "now: %s" (now.ToString())
    printfn "best F1 pilot on the grid: %s" pilotFirstName
    printfn "best F1 pilot on the grid with new first name: %s" (getPilotFirstName newPilot)

    printfn "%s" Environment.NewLine
    printfn "it will evaluate only 5 of them, 2 to skip, 3 to take"
    printfn "%s" Environment.NewLine

    getNumbers |> Seq.skip 2 
        |> Seq.take 3 
        |> Seq.iter (fun elem -> printfn "num: %i" elem) 
        |> ignore

    printfn "%s" Environment.NewLine
    printfn "this time Seq.sort will evaluate all of them at once"
    printfn "%s" Environment.NewLine

    getNumbers |> Seq.sort 
        |> Seq.skip 2 
        |> Seq.take 3 
        |> Seq.iter (fun elem -> printfn "num: %i" elem) 
        |> ignore

    0 // return an integer exit code