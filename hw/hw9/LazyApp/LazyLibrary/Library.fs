namespace Lazy

open System
open System.Threading

/// <summary>
/// Interface for lazy computations
/// </summary>
type ILazy<'a> =
    abstract member Get: unit -> 'a

/// <summary>
/// Implements ILazy interface for single threaded mode
/// </summary>
type SingleThreadedLazy<'a when 'a: equality>(supplier: unit -> 'a) =
    let mutable result: 'a = Unchecked.defaultof<'a>
    let mutable calculated = false

    interface ILazy<'a> with
        member this.Get() = 
            if (not calculated)
            then result <- supplier()
                 calculated <- true
            result          
        
/// <summary>
/// Implements ILazy interface for multi threaded mode
/// </summary>        
 type MultiThreadedLazy<'a when 'a: equality>(supplier : unit -> 'a) =
        [<VolatileField>]
        let mutable result: 'a = Unchecked.defaultof<'a>
        [<VolatileField>]
        let mutable calculated = false
        let lockobj = new Object()
        
        interface ILazy<'a> with
            member this.Get() =
                if (not calculated)
                then lock(lockobj)(fun () -> if (not calculated) then result <- supplier()
                                                                      calculated <- true)
                result

/// <summary>
/// Implements ILazy interface for multi threaded mode lock-free
/// </summary>
type LockFreeLazy<'a when 'a: equality and 'a: not struct>(supplier : unit -> 'a) =
        let mutable result = ref Unchecked.defaultof<'a>
        let mutable calculated = false
       
        interface ILazy<'a> with
            member this.Get() = 
                if (not calculated)
                then Interlocked.CompareExchange(result, supplier(), Unchecked.defaultof<'a>) |> ignore
                     calculated <- true
                result.contents
          
/// <summary>
/// Class for lazy computations with various ILazy implementations
/// </summary>
type LazyFactory() = 

     /// <summary>
     /// Creates ILazy implementations for single threaded computations
     /// </summary>
     /// <param name="supplier">Function that is evaluated only when the result is required</param>
     static member CreateSingleThreadedLazy(supplier : unit -> 'a) =
        SingleThreadedLazy<'a>(supplier) :> ILazy<'a>

     /// <summary>
     /// Creates ILazy implementations for multi threaded computations
     /// </summary>
     /// <param name="supplier">Function that is evaluated only when the result is required</param>
     static member CreateMultiThreadedLazy(supplier : unit -> 'a) =
        MultiThreadedLazy<'a>(supplier) :> ILazy<'a>

     /// <summary>
     /// Creates ILazy implementations for multi threaded computations which is lock-free
     /// </summary>
     /// <param name="supplier">Function that is evaluated only when the result is required</param>
     static member CreateLockFreeLazy(supplier : unit -> 'a) =
        LockFreeLazy<'a>(supplier) :> ILazy<'a>
