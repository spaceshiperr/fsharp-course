namespace Homework3

open Homework3.Task3
open NUnit.Framework
open FsUnit

module Task3Tests = 

    [<Test>]
    let ``Evaluate of 11 - (1 + 9 / 2) * 5 should return -14`` () = 
        let exp = Minus(Const(11), Product(Plus(Const(1), Division(Const(9), Const(2))), Const(5)))
        let expected = -14
        let actual = evaluate(exp)
        actual |> should equal expected

    [<Test>]
    let ``Evaluate of 0 should return 0`` () = 
        let exp = Const(0)
        let expected = 0
        let actual = evaluate(exp)
        actual |> should equal expected

        
    [<Test>]
    let ``Evaluate of 1 + 2 / 0 should throw System.DivideByZeroException`` () = 
        let exp = Plus(Const(1), Division(Const(2), Const(0)))
        (fun () -> evaluate(exp) |> ignore) |> should throw typeof<System.DivideByZeroException>