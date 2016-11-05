// Learn more about F# at http://fsharp.org

open System

// https://fsharpforfunandprofit.com/posts/recipe-part3/
// https://fsharpforfunandprofit.com/posts/organizing-functions/

// "types-only" module
[<AutoOpen>]
module DomainTypes =

    [<StructuralEquality;NoComparison>]
    type PersonalName = {FirstName: string; LastName: string}

    [<NoEquality;NoComparison>]
    type Person = {Id: int; Name: PersonalName}

module Person =

    // constructor
    let create first last = 
        {Id=1;Name={FirstName=first; LastName=last}}

    // method that works on the type
    let fullName (x:Person) = 
        x.Name.FirstName + " " + x.Name.LastName

module Utils =

    let getFirstName (x:Person) = x.Name.FirstName

    let addThreeNumbers x y z = 

        // create a nested helper func
        let add n =
            fun x -> x + n

        x |> (add y) |> (add z)

    let sumNumbersUpTo max = 

        // recursive helper function with accumulator
        let rec recursiveSum n sumSoFar =
            match n with
            | 0 -> sumSoFar
            | _ -> recursiveSum (n-1) (n+sumSoFar)

        recursiveSum max 0

[<EntryPoint>]
let main argv = 
    printfn "Hello World!"
    printfn "%A" argv
    let person = Person.create "Tugberk" "Ugurlu"
    let threeNumbers = Utils.addThreeNumbers 1 2 3
    let summedUpTo20 = Utils.sumNumbersUpTo 20
    printfn "%s" (Utils.getFirstName person)
    printfn "%s" (Person.fullName person)
    printfn "Three numbers added together: %i" threeNumbers
    printfn "Summed numbers up to 20: %i" summedUpTo20

    0 // return an integer exit code