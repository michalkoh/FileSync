namespace FileSync

module App =

    [<EntryPoint>]
    let main (argv: string array) =
        let argvList: string list = argv |> Array.toList
        let input: Input.CommandLineOptions = Input.parseCommandLine argvList
        Synchronize.sync input
        0