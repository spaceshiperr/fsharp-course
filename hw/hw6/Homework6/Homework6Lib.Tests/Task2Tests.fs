namespace Homework6

open NUnit.Framework
open FsUnit
open Homework6.Task2

module Task2Tests = 

    [<Test>]
    let ``Test1`` () =
        let os = new OS()
        os.SetInfectionProbability 1.0 0.0 0.0
        let lan = new Lan([|new Computer(Windows, false)|], Array2D.create 1 1 true, os)
        lan.Next()
        (lan.Computers.Length = 1 && lan.Computers.[0].isInfected = false) |> should be True

    [<Test>]
    let ``Test2`` () =
        let os = new OS()
        os.SetInfectionProbability 1.0 0.0 1.0
        let lan = new Lan([|new Computer(MacOS, true); new Computer(Linux, false)|], Array2D.create 2 2 false, os)
        for i in 0..100 do
            lan.Next()
        let comp = lan.Computers
        (comp.Length = 2 && comp.[0].isInfected = true && comp.[1].isInfected = false) |> should be True

    [<Test>]
    let ``Test3`` () =
        let os = new OS()
        os.SetInfectionProbability 1.0 1.0 0.5
    
        let mutable matrix = Array2D.create 3 3 true
        matrix.[0, 1] <- false
        matrix.[0, 2] <- false
        matrix.[1, 0] <- false
        matrix.[2, 0] <- false

        let lan = new Lan([|new Computer(Windows, false); new Computer(Linux, false); new Computer(MacOS, true)|], matrix, os)
        lan.Next()
        let comp = lan.Computers
        (lan.Computers.[0].isInfected = false && comp.[1].isInfected = true) |> should be True