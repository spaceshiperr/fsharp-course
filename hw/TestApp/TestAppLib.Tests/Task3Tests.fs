namespace TestApp

open TestApp.Task3
open NUnit.Framework
open FsUnit

module Task3Tests = 
    
    [<Test>]
    let ``IsEmpty of an initially empty int stack should return true`` () = 
        let mutable stack = Stack<int>()
        stack.IsEmpty() |> should equal true
    
    [<Test>]
    let ``IsEmpty of cleared by user int stack should return false``() = 
        let mutable stack = Stack<int>()
        stack.Push 1
        stack.Push 2
        stack.Pop()
        stack.Pop()
        stack.IsEmpty() |> should equal true

    [<Test>]
    let ``IsEmpty of non empty string stack should return false``() = 
        let mutable stack = Stack<string>()
        stack.Push "hello"
        stack.Push "world"
        stack.IsEmpty() |> should equal false


    [<Test>]
    let ``Pop for an empty stack should raise System.InvalidOperationException``() = 
        let mutable stack = Stack<string>()
        (fun () -> stack.Pop() |> ignore) |> should throw typeof<System.InvalidOperationException>

    [<Test>]
    let ``Pop should return the value of last element pushed into the stack``() = 
        let mutable stack = Stack<string>()
        stack.Push "you"
        stack.Push "shall"
        stack.Push "not"
        stack.Push "pass"
        stack.Pop() |> should equal "pass"
