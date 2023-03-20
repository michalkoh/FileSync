namespace Test

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open FileSync.Input

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing () =
    
        let options: CommandLineOptions = parseCommandLine ["/v"; "/s"] 
        Assert.IsNotNull(options);
        Assert.IsTrue(options.verbose);