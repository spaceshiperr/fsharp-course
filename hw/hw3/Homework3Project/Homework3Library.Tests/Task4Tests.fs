namespace Homework3

open Homework3.Task4
open NUnit.Framework
open FsUnit

module Task4Tests = 

    [<Test>]
    let ``First 10 numbers of primes should be 2, 3, 5, 7, 11, 13, 17, 19, 23, 29`` () = 
        let expected = seq { for i in 2I .. 30I do if isPrime <| i then yield i }
        let actual = Seq.take 10 <| primes
        actual |> should equal expected