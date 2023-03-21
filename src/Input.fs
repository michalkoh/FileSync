namespace FileSync

module Input = 

    type CommandLineOptions = {
        verbose: bool
        source: string
        target: string
    }

    let rec parseCommandLineRec (args: string list) (optionsSoFar: CommandLineOptions) =
        match args with
        // empty list
        | [] -> optionsSoFar

        // verbose
        | "/v"::xs ->
            let newOptionsSoFar: CommandLineOptions = { optionsSoFar with verbose = true }
            parseCommandLineRec xs newOptionsSoFar 

        // source
        | "/s"::xs ->
            // submatch
            match xs with 
            | first::rest ->
                let newOptionsSoFar: CommandLineOptions = { optionsSoFar with source = first }
                parseCommandLineRec rest newOptionsSoFar
            |_ ->
                eprintfn "Option /s is mandantory and specifies the source directory."
                parseCommandLineRec xs optionsSoFar

        // target
        | "/t"::xs ->
            // submatch
            match xs with 
            | first::rest ->
                let newOptionsSoFar: CommandLineOptions = { optionsSoFar with target = first }
                parseCommandLineRec rest newOptionsSoFar
            |_ ->
                eprintfn "Option /t is mandantory and specifies the target directory."
                parseCommandLineRec xs optionsSoFar

        // default case
        |x::xs ->
            eprintfn "Options '%s' not recognized." x
            parseCommandLineRec xs optionsSoFar

    let parseCommandLine args = 
        let defaultOptions: CommandLineOptions = {
            verbose = true;
            source = ".";
            target = ".";
            }
        
        parseCommandLineRec args defaultOptions