namespace Homework7

open NUnit.Framework
open FsUnit
open Homework7.Task2

module Task2Tests = 

    [<Test>]
    let ``NumberBuilder for "1" + "2" should return Some 3``() = 
        let numberFlow = new NumberBuilder()
        let result = numberFlow {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
        }
        result.Value |> should equal 3

    [<Test>]
    let ``NumberBuilder for "1" + "Ъ" should return None``() = 
        let numberFlow = new NumberBuilder()
        let result = numberFlow {
            let! x = "1"
            let! y = "Ъ"
            let z = x + y
            return z
        }
        result |> should equal None
