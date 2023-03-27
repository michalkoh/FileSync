namespace FileSync

open System.IO

module Synchronize =

    let sync (input: Input.CommandLineOptions): unit =
        let subdirs: string array = Directory.GetDirectories(input.source, "*", SearchOption.AllDirectories)

        subdirs
        |> Array.map (fun d -> d.Substring(input.source.Length))
        |> Array.iter (fun (d: string) -> printfn "%s" d)

    (*let sync (currentDir: string, input: Input.CommandLineOptions): unit =
        let source = 
        if (Directory.Exists())*)
