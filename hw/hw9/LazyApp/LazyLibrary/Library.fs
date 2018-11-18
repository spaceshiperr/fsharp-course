namespace Lazy

open System
open System.Threading

type ILazy<'a> =
    abstract member Get: unit -> 'a

type SingleThreadedLazy<'a when 'a: equality>(supplier: unit -> 'a) =
    let mutable result: 'a = Unchecked.defaultof<'a>

    interface ILazy<'a> with
        member this.Get() = 
            if (result = Unchecked.defaultof<'a>)
            then result <- supplier()
            result          
            
 type MultiThreadedLazy<'a when 'a: equality>(supplier : unit -> 'a) =
        let mutable result: 'a = Unchecked.defaultof<'a>
        let lockobj = new Object()
        
        interface ILazy<'a> with
            member this.Get() =
                lock(lockobj)(fun () -> if (result = Unchecked.defaultof<'a>)
                                        then result <- supplier())
                result

type LockFreeLazy<'a when 'a: equality and 'a: not struct>(supplier : unit -> 'a) =
        let mutable result = ref Unchecked.defaultof<'a>
       
        interface ILazy<'a> with
            member this.Get() = 
                if (result = ref Unchecked.defaultof<'a>)
                then Interlocked.CompareExchange(result, supplier(), Unchecked.defaultof<'a>) |> ignore
                result.contents
                
type LazyFactory() = 
     static member CreateSingleThreadedLazy(supplier : unit -> 'a) =
        SingleThreadedLazy<'a>(supplier) :> ILazy<'a>

     static member CreateMultiThreadedLazy(supplier : unit -> 'a) =
        MultiThreadedLazy<'a>(supplier) :> ILazy<'a>

     static member CreateLockFreeLazy(supplier : unit -> 'a) =
        LockFreeLazy<'a>(supplier) :> ILazy<'a>