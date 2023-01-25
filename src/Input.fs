namespace FileSync

module Input = 

    type CommandLineOptions = {
        verbose: bool
        source: string
        destination: string
    }

    let rec parseCommandLine args optionsSoFar =
        match args with
        // empty list
        | [] -> optionsSoFar

        // verbose
        | "/v"::xs ->
            let newOptionsSoFar = { optionsSoFar with verbose=true }
            parseCommandLine xs newOptionsSoFar 

        // default case
        |x::xs ->
            eprintfn "Options '%s' not recognized" x
            parseCommandLine xs optionsSoFar