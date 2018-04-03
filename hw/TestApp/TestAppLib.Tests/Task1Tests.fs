namespace TestApp

open TestApp.Task1
open NUnit.Framework
open FsUnit
open System

module Task1Tests = 
    
    [<Test>]
    let ``averageSin of [1.2; 2.1; 3.2] should equal 0.578958`` () = 
        averageSin [1.2; 2.1; 3.2] |> should (equalWithin 0.001) 0.578958

    [<Test>]
    let ``averageSin of [] should throw System.ArgumentNullException`` () = 
        (fun () -> averageSin [] |> ignore) |> should throw typeof<System.ArgumentNullException>

    [<Test>]
    let ``averageSin of [Math.PI] should equal 0`` () = 
        averageSin [Math.PI] |> should (equalWithin 0.001) 0