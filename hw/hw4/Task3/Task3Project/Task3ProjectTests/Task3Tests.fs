namespace Homework4

open Homework4.Task3
open NUnit.Framework
open FsUnit

module Task3Tests = 
    
    let var x = Variable(x)
    let x = var "x"
    //let y = var "y"
    //let z = var "z"
    let I = Abstraction(x, Variable(x))
    //let S = Abstraction(x, Abstraction(y, Abstraction(z, Application(Application(var x, var z), Application(var y, var z)))))
    //let K = Abstraction(x, Abstraction(y, var x))
    //let K' = Abstraction(x, Abstraction(y, var y))
    
    [<Test>]
    let ``evaluate of lambda expression should return beta-reduced expression`` () = 
        let exp = Application(Abstraction("f", Abstraction("x", Application(Application(Variable("f"), Variable("x")), Variable("x")))), Variable("+"))
        let expected = Abstraction("x", Application (Application (Variable "+", Variable "x"), Variable "x"))
        let actual = evaluate exp
        actual |> should equal expected

    [<Test>]
    let ``evaluate of I I should return I`` () = 
        evaluate <| Application(I, I) |> should equal I