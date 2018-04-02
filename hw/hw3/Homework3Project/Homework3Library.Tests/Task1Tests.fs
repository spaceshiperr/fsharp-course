namespace Homework3 

open Homework3.Task1
open NUnit.Framework
open FsUnit

module Task1Tests = 

        [<Test>]
        let ``countEvenNumbersByMap of [0; 1; 2; 3; 4; 5; 6] should return 4`` () = 
            countEvenNumbersByMap [0; 1; 2; 3; 4; 5; 6] |> should equal 4

        [<Test>]
        let ``countEvenNumbersByFilter of [0; 1; 2; 3; 4; 5; 6] should return 4`` () = 
            countEvenNumbersByFilter [0; 1; 2; 3; 4; 5; 6] |> should equal 4

        [<Test>]
        let ``countEvenNumbersByFold of [0; 1; 2; 3; 4; 5; 6] should return 4`` () = 
            countEvenNumbersByFold [0; 1; 2; 3; 4; 5; 6] |> should equal 4

        [<Test>]
        let ``countEvenNumbersByMap of [] should return 0`` () = 
            countEvenNumbersByMap [] |> should equal 0

        [<Test>]
        let ``countEvenNumbersByFilter of [] should return 0`` () = 
            countEvenNumbersByFilter [] |> should equal 0

        [<Test>]
        let ``countEvenNumbersByFold of [] should return 0`` () = 
             countEvenNumbersByFold [] |> should equal 0

        [<Test>]
        let ``countEvenNumbersByMap of [0] should return 1`` () = 
            countEvenNumbersByMap [0] |> should equal 1

        [<Test>]
        let ``countEvenNumbersByFilter of [0] should return 1`` () = 
            countEvenNumbersByFilter [0] |> should equal 1

        [<Test>]
        let ``countEvenNumbersByFold of [0] should return 1`` () = 
            countEvenNumbersByFold [0] |> should equal 1

        [<Test>]
        let ``countEvenNumbersByMap of [-1; 0; -8; 4; -2; 7] should return 4`` () = 
            countEvenNumbersByMap [-1; 0; -8; 4; -2; 7] |> should equal 4

        [<Test>]
        let ``countEvenNumbersByFilter of [-1; 0; -8; 4; -2; 7] should return 4`` () = 
            countEvenNumbersByFilter [-1; 0; -8; 4; -2; 7] |> should equal 4

        [<Test>]
        let ``countEvenNumbersByFold of [-1; 0; -8; 4; -2; 7] should return 4`` () = 
            countEvenNumbersByFold [-1; 0; -8; 4; -2; 7] |> should equal 4
