namespace Homework7

open NUnit.Framework
open FsUnit
open Homework7.Task1
open System

module Task1Tests = 

    [<Test>]
    let ``RoundBuilder(3) for 2.0 / 12.0 / 3.5 should return 0.048``() = 
        let rounding3 = new RoundBuilder(3)
        let result = rounding3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }
        result |> should equal 0.048

    [<Test>]
    let ``RoundBuilder(0) for PI / sqrt(PI + 1.0) should return 2``() = 
        let rounding0 = new RoundBuilder(0)
        let result = rounding0 {
            let! a = Math.PI
            let! b = Math.Sqrt(Math.PI + 1.0)
            let! c = a / b
            return c
        }
        result |> should equal 2

    [<Test>]
    let ``RoundBuilder(2) for 1.23456 should return 1.23``() = 
        let rounding2 = new RoundBuilder(2)
        let result = rounding2 {
            return 1.23456
        }
        result |> should equal 1.23
