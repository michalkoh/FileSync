namespace FileSync

module Input = 

    type CommandLineOptions = {
        verbose: bool
        source: string
        destination: string
    }

    let rec parseCommandLineRec (args: string list) (optionsSoFar: CommandLineOptions) =
        match args with
        // empty list
        | [] -> optionsSoFar

        // verbose
        | "/v"::xs ->
            let newOptionsSoFar = { optionsSoFar with verbose=true }
            parseCommandLineRec xs newOptionsSoFar 

        // default case
        |x::xs ->
            eprintfn "Options '%s' not recognized" x
            parseCommandLineRec xs optionsSoFar

    let parseCommandLine args = 
        let defaultOptions = {
            verbose = true;
            source = ".";
            destination = ".";
            }
        
        parseCommandLineRec args defaultOptions