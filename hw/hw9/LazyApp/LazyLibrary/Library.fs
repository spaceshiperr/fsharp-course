namespace Lazy

open System
open System.Threading

type ILazy<'a> =
    abstract member Get: unit -> 'a

type SingleThreadedLazy<'a when 'a: equality>(supplier: unit -> 'a) =
    let mutable result: 'a = Unchecked.defaultof<'a>
    let mutable calculated = false

    interface ILazy<'a> with
        member this.Get() = 
            if (not calculated)
            then result <- supplier()
                 calculated <- true
            result          
            
 type MultiThreadedLazy<'a when 'a: equality>(supplier : unit -> 'a) =
        let mutable result: 'a = Unchecked.defaultof<'a>
        let mutable calculated = false
        let lockobj = new Object()
        
        interface ILazy<'a> with
            member this.Get() =
                lock(lockobj)(fun () -> if (not calculated)
                                        then result <- supplier()
                                             calculated <- true )
                result

type LockFreeLazy<'a when 'a: equality and 'a: not struct>(supplier : unit -> 'a) =
        let mutable result = ref Unchecked.defaultof<'a>
        let mutable calculated = false
       
        interface ILazy<'a> with
            member this.Get() = 
                if (not calculated)
                then Interlocked.CompareExchange(result, supplier(), Unchecked.defaultof<'a>) |> ignore
                     calculated <- true
                result.contents
                
type LazyFactory() = 
     static member CreateSingleThreadedLazy(supplier : unit -> 'a) =
        SingleThreadedLazy<'a>(supplier) :> ILazy<'a>

     static member CreateMultiThreadedLazy(supplier : unit -> 'a) =
        MultiThreadedLazy<'a>(supplier) :> ILazy<'a>

     static member CreateLockFreeLazy(supplier : unit -> 'a) =
        LockFreeLazy<'a>(supplier) :> ILazy<'a>