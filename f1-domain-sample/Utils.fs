namespace F1Graph

    module Utils =

        let randomString =
            let chars = "ABCDEFGHIJKLMNOPQRSTUVWUXYZ0123456789"
            let charsLength = chars.Length
            let random = System.Random()

            fun len -> 
                let randomChars = [|for i in 0..len -> chars.[random.Next(charsLength)]|]
                new System.String(randomChars)