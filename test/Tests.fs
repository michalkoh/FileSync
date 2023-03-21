namespace FileSync

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open FileSync.Input

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.ParseCommandLine_ValidOptions_Passed () =

        let options: CommandLineOptions = parseCommandLine ["/v"; "/p"; "/s"; "source_path"; "/t"; "target_path"] 
        Assert.IsNotNull(options);
        Assert.IsTrue(options.verbose);
        Assert.IsTrue(options.preview);
        Assert.AreEqual("source_path", options.source);
        Assert.AreEqual("target_path", options.target);