namespace Test

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open FileSync.Input

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing () =
        let defaultOptions = { 
            verbose = false;
            source = "quelle";
            destination = "ziels" 
        }

        let options = parseCommandLine ["/v"; "/s"]  defaultOptions
        Assert.IsNotNull(options);
        Assert.IsTrue(options.verbose)
        Assert.IsFalse(options.verbose)