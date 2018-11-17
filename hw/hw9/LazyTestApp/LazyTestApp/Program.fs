open System
open System.Threading

type ILazy<'a> =
    abstract member Get: unit -> 'a

type SingleThreadedLazy<'a when 'a: equality>(supplier: unit -> 'a) =
    let mutable result: 'a = Unchecked.defaultof<'a>

    interface ILazy<'a> with
        member this.Get() = 
            if (result <> Unchecked.defaultof<'a>)
            then result <- supplier()
            result                

type LazyFactory() = 
     static member CreateSingleThreadedLazy(supplier : unit -> 'a) =
        SingleThreadedLazy<'a>(supplier) :> ILazy<'a>


[<EntryPoint>]
let main argv =
    Console.ReadLine()
    0
