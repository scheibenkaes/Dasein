module Dasein.Core

type Entity = {
    Id: string;
    Components : Map<string,obj>
}

let newEntity id = {Id = id; Components = Map.empty}

let addComponent comp entity =
    {entity with 
        Components = Map.add (comp.GetType().ToString())
                             (comp)
                             (entity.Components)}

let getComponent<'T> entity : 'T option =
    let typeName = typeof<'T>.ToString()
    let comp = entity.Components.TryFind(typeName)
    match comp with
    | None -> None
    | Some c -> Some (c :?> 'T)

let getComponentValue<'T> entity : 'T =
    getComponent<'T> entity |> Option.get
