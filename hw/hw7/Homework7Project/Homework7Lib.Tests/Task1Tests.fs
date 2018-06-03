namespace Homework7

open NUnit.Framework
open FsUnit
open Homework7.Task1
open System

module Task1Tests = 

    [<Test>]
    let ``RoundBuilder(3) for 2.0 / 12.0 / 3.5 should return Some 0.048``() = 
        let rounding3 = new RoundBuilder(3)
        let result = rounding3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }
        result |> should equal <| Some 0.048

    [<Test>]
    let ``RoundBuilder(0) for PI / sqrt(PI + 1.0) should return Some 2``() = 
        let rounding0 = new RoundBuilder(0)
        let result = rounding0 {
            let! a = Math.PI
            let! b = Math.Sqrt(Math.PI + 1.0)
            let! c = a / b
            return c
        }
        result |> should equal <| Some 2.0

    [<Test>]
    let ``RoundBuilder(2) for 1.23456 should return Some 1.23``() = 
        let rounding2 = new RoundBuilder(2)
        let result = rounding2 {
            return 1.23456
        }
        result |> should equal <| Some 1.23

    [<Test>]
    let ``RoundBuilder(16) for 3.14 should return None``() = 
        let rounding16 = new RoundBuilder(16)
        let result = rounding16 {
            return 3.14
        }
        result |> should equal None

    [<Test>]
    let ``RoundBuilder(-1) for 2.71 should return None``() = 
        let roundingNegative = new RoundBuilder(-1)
        let result = roundingNegative {
            return 2.71
        }
        result |> should equal None



