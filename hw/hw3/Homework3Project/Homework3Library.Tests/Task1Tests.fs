namespace Homework3 

open Homework3.Task1
open NUnit.Framework
open FsUnit

module Task1Tests = 

        [<Test>]
        let ``countEvenNumbers1 of [0; 1; 2; 3; 4; 5; 6] should return 4`` () = 
            countEvenNumbers1 [0; 1; 2; 3; 4; 5; 6] |> should equal 4

        [<Test>]
        let ``countEvenNumbers2 of [0; 1; 2; 3; 4; 5; 6] should return 4`` () = 
            countEvenNumbers2 [0; 1; 2; 3; 4; 5; 6] |> should equal 4

        [<Test>]
        let ``countEvenNumbers3 of [0; 1; 2; 3; 4; 5; 6] should return 4`` () = 
            countEvenNumbers3 [0; 1; 2; 3; 4; 5; 6] |> should equal 4

        [<Test>]
        let ``countEvenNumbers1 of [] should return 0`` () = 
            countEvenNumbers1 [] |> should equal 0

        [<Test>]
        let ``countEvenNumbers2 of [] should return 0`` () = 
            countEvenNumbers2 [] |> should equal 0

        [<Test>]
        let ``countEvenNumbers3 of [] should return 0`` () = 
             countEvenNumbers3 [] |> should equal 0

        [<Test>]
        let ``countEvenNumbers1 of [0] should return 1`` () = 
            countEvenNumbers1 [0] |> should equal 1

        [<Test>]
        let ``countEvenNumbers2 of [0] should return 1`` () = 
            countEvenNumbers2 [0] |> should equal 1

        [<Test>]
        let ``countEvenNumbers3 of [0] should return 1`` () = 
            countEvenNumbers3 [0] |> should equal 1

        [<Test>]
        let ``countEvenNumbers1 of [-1; 0; -8; 4; -2; 7] should return 4`` () = 
            countEvenNumbers1 [-1; 0; -8; 4; -2; 7] |> should equal 4

        [<Test>]
        let ``countEvenNumbers2 of [-1; 0; -8; 4; -2; 7] should return 4`` () = 
            countEvenNumbers2 [-1; 0; -8; 4; -2; 7] |> should equal 4

        [<Test>]
        let ``countEvenNumbers3 of [-1; 0; -8; 4; -2; 7] should return 4`` () = 
            countEvenNumbers3 [-1; 0; -8; 4; -2; 7] |> should equal 4
