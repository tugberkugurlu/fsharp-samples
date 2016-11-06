namespace F1Graph

    [<StructuralEquality;NoComparison>]
    type PersonalName = {FirstName: string; LastName: string}

    [<AutoOpen>]
    module Pilot =

        [<NoEquality;NoComparison>]
        type Pilot = {Id: string; Name: PersonalName}

        let create first last =
            {Id=(Utils.randomString 20);Name={FirstName=first; LastName=last}}