namespace Homework3 

open Homework3.Task1
open NUnit.Framework
open FsUnit

module Task1Tests = 

        [<Test>]
        let ``countEvenNumbers1 of [0; 1; 2; 3; 4; 5; 6] should return 4`` () = 
            let list = [0; 1; 2; 3; 4; 5; 6]
            let expected = 4            
            let actual = countEvenNumbers1 list
            actual |> should equal expected

        [<Test>]
        let ``countEvenNumbers2 of [0; 1; 2; 3; 4; 5; 6] should return 4`` () = 
            let list = [0; 1; 2; 3; 4; 5; 6]
            let expected = 4            
            let actual = countEvenNumbers2 list
            actual |> should equal expected

        [<Test>]
        let ``countEvenNumbers3 of [0; 1; 2; 3; 4; 5; 6] should return 4`` () = 
            let list = [0; 1; 2; 3; 4; 5; 6]
            let expected = 4            
            let actual = countEvenNumbers3 list
            actual |> should equal expected

        [<Test>]
        let ``countEvenNumbers1 of [] should return 0`` () = 
            let list = []
            let expected = 0
            let actual = countEvenNumbers1 list
            actual |> should equal expected

        [<Test>]
        let ``countEvenNumbers2 of [] should return 0`` () = 
            let list = []
            let expected = 0
            let actual = countEvenNumbers2 list
            actual |> should equal expected

        [<Test>]
        let ``countEvenNumbers3 of [] should return 0`` () = 
            let list = []
            let expected = 0
            let actual = countEvenNumbers3 list
            actual |> should equal expected

        [<Test>]
        let ``countEvenNumbers1 of [0] should return 1`` () = 
            let list = [0]
            let expected = 1
            let actual = countEvenNumbers1 list
            actual |> should equal expected

        [<Test>]
        let ``countEvenNumbers2 of [0] should return 1`` () = 
            let list = [0]
            let expected = 1
            let actual = countEvenNumbers2 list
            actual |> should equal expected

        [<Test>]
        let ``countEvenNumbers3 of [0] should return 1`` () = 
            let list = [0]
            let expected = 1
            let actual = countEvenNumbers3 list
            actual |> should equal expected

        [<Test>]
        let ``countEvenNumbers1 of [-1; 0; -8; 4; -2; 7] should return 4`` () = 
            let list = [-1; 0; -8; 4; -2; 7]
            let expected = 4
            let actual = countEvenNumbers1 list
            actual |> should equal expected

        [<Test>]
        let ``countEvenNumbers2 of [-1; 0; -8; 4; -2; 7] should return 4`` () = 
            let list = [-1; 0; -8; 4; -2; 7]
            let expected = 4
            let actual = countEvenNumbers2 list
            actual |> should equal expected

        [<Test>]
        let ``countEvenNumbers3 of [-1; 0; -8; 4; -2; 7] should return 4`` () = 
            let list = [-1; 0; -8; 4; -2; 7]
            let expected = 4
            let actual = countEvenNumbers3 list
            actual |> should equal expected
    
    
