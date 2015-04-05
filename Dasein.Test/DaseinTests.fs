namespace DaseinTests

open NUnit.Framework
open FsUnit

[<TestFixture>]
type public ``entities can be extended by components`` () =
    [<Test>]
    member this.``test`` () = 
        1 |> should equal 1
