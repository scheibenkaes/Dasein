namespace DaseinTests

open NUnit.Framework
open FsUnit

open Dasein.Core

type Renderable = {
    text: string
}

type FancyComponent = {
    Foo: int
}

[<TestFixture>]
type public ``getComponentValue acts as expected`` () =
    let e = newEntity "asd"

    [<Test>]
    member x.``finds value if it's there`` () =
        e |> addComponent {Foo = 100} |> getComponentValue<FancyComponent> |> should equal {Foo = 100}

    [<Test>]
    member x.``throws when it cannot find the component`` () =
        (fun () -> getComponentValue<Renderable> e |> ignore) |> should throw typeof<System.ArgumentException>

[<TestFixture>]
type public ``entities can be extended by components`` () =
    let e = {Id = "asd"; Components = Map.empty}

    let renderable = addComponent {text = "asd"} e

    [<Test>]
    member this.``adding components can be pipelined``() =
        e
        |> addComponent {text ="asd"}
        |> addComponent {Foo = 123}
        |> getComponent<FancyComponent>
        |> Option.isSome |> should equal true

    [<Test>]
    member this.``newEntity sets up the value as expected`` () = 
        newEntity "asd" |> should equal {Id = "asd"; Components = Map.empty}

    [<Test>]
    member this.``looking for a non existent component returns None`` () = 
        getComponent<Renderable> e |> should equal None
        
    [<Test>]
    member this.``looking for an existing component returns the component`` () = 
        let r = getComponent<Renderable> renderable
        r |> Option.get |> should equal {text = "asd"}