namespace Homework4

open Homework4.Task3
open NUnit.Framework
open FsUnit

module Task3Tests = 
    
    [<Test>]
    let ``evaluate of lambda expression should return beta-reduced expression`` () = 
        let exp = Application(Abstraction("f", Abstraction("x", Application(Application(Variable("f"), Variable("x")), Variable("x")))), Variable("+"))
        let expected = Abstraction("x", Application (Application (Variable "+", Variable "x"), Variable "x"))
        let actual = evaluate exp
        actual |> should equal expected

    [<Test>]
    let ``evaluate of I I should return I`` () = 
        let I = Abstraction(Variable("x"), Variable(Variable("x")))
        let expected = I
        let actual = evaluate <| Application(I, I) 
        actual |> should equal expected