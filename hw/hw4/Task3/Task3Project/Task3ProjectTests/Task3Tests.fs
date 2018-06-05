namespace Homework4

open Homework4.Task3
open NUnit.Framework
open FsUnit

module Task3Tests = 
    
    [<Test>]
    let ``evaluate of lambda expression should return beta-reduced expression`` () = 
        let exp = Application(Abstraction('f', Abstraction('x', Application(Application(Variable('f'), Variable('x')), Variable('x')))), Variable('+'))
        let expected = Abstraction('x', Application (Application (Variable '+', Variable 'x'), Variable 'x'))
        let actual = evaluate exp
        actual |> should equal expected

    [<Test>]
    let ``evaluate of I I should return I`` () = 
        let I = Abstraction('x', Variable('x'))
        let expected = I
        let actual = evaluate <| Application(I, I) 
        actual |> should equal expected

    [<Test>]
    let ``Alpha conversion should work even when there are name conflicts`` () = 
        let initialExpression = Abstraction('x', Variable('y'))
        let substitutionExpression = Abstraction('z', Variable('x'))
        let actual = substitute initialExpression 'y' substitutionExpression
        let expected = Abstraction('a', Abstraction('z', Variable('x')))
        expected |> should equal actual