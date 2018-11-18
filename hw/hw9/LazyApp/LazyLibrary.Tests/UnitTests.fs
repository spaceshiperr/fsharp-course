namespace Lazy.Tests

open NUnit.Framework
open FsUnit

module Tests =

    open Lazy
    open System.Threading

    type SupplierExample() = 
        let mutable count = 0
        member this.Supplier() = 
            count <- count + 1
            box count
        member this.Count = count

    [<Test>]
    let ``SingleThreadedLazy with SupplierExample's supplier method should be computed once``() = 
        let supplierExample = SupplierExample()
        let ilazy = LazyFactory.CreateSingleThreadedLazy(supplierExample.Supplier)
        ilazy.Get() |> ignore
        ilazy.Get() |> ignore
        ilazy.Get() |> ignore
        supplierExample.Count |> should equal 1

    [<Test>]
    let ``MultiThreadedLazy with SupplierExample's supplier method should be computed once among all threads``() = 
        let supplierExample = SupplierExample()
        let ilazy = LazyFactory.CreateMultiThreadedLazy(supplierExample.Supplier)
        let threads = List.init 5 (fun i -> new Thread(fun () -> ilazy.Get() |> ignore))
        List.iter (fun (thread: Thread) -> thread.Start()) threads
        List.iter (fun (thread: Thread) -> thread.Join()) threads
        supplierExample.Count |> should equal 1


    [<Test>]
    let ``LockFreeLazy with SupplierExample's supplier method should be computed once``() = 
        let supplierExample = SupplierExample()
        let ilazy = LazyFactory.CreateLockFreeLazy(supplierExample.Supplier)
        ilazy.Get() |> ignore
        ilazy.Get() |> ignore
        ilazy.Get() |> ignore
        supplierExample.Count |> should equal 1

    [<Test>]
    let ``LockFreeLazy with (fun () -> box "test") method should return "test"``() = 
        let ilazy = LazyFactory.CreateLockFreeLazy((fun () -> box "test"))
        let threads = List.init 5 (fun i -> new Thread(fun () -> ilazy.Get() |> should equal "test"))
        List.iter (fun (thread: Thread) -> thread.Start()) threads
        List.iter (fun (thread: Thread) -> thread.Join()) threads

        
        

