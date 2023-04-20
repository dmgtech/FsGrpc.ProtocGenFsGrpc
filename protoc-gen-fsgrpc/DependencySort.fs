module DependencySort

open System

type DepthVal =
| Depth of int
| Recursive

let depSort<'T when 'T : equality> (getDeps: Func<'T, 'T seq>) =
    let rec dependencyLevel (path: 'T list) (thing: 'T) : DepthVal  =
        if path |> Seq.contains thing then
            Recursive
        else
            let deps = getDeps.Invoke thing |> Seq.toList
            if deps |> List.isEmpty then
                Depth 0
            else
                let recurse = dependencyLevel (thing :: path)
                let maxdep = deps |> List.maxBy recurse |> recurse
                match maxdep with
                | Recursive -> Recursive
                | Depth n -> Depth (n + 1)

    Func<_, _>(fun thing -> struct (dependencyLevel [] thing, thing))