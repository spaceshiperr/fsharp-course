namespace Homework5

open NUnit.Framework
open FsUnit
open Homework5.Task1

module Task1Tests = 

    let testStrings = 
            [
                TestCaseData("(hello) <world{!}>", ('{', '}'), ('<', '>'), ('(', ')')).Returns(true)
                TestCaseData("no brackets here", ('{', '}'), ('<', '>'), ('(', ')')).Returns(true)
                TestCaseData("1<ab>22", ('1', '2'), ('<', '>'), ('a', 'b')).Returns(false)
                TestCaseData("11bb", ('1', '2'), ('<', '>'), ('a', 'b')).Returns(false)
            ]
    
    [<TestCaseSource("testStrings")>]
    let ``isCorrectString of a string that might have 3 types of brackets tells if they are nested correctly`` str = 
        isCorrectString str

    [<Test>]
    let ``isCorrectString of an empty string should throw System.ArgumentException`` () = 
        (fun () -> isCorrectString("", ('{', '}'), ('<', '>'), ('(', ')')) |> ignore) |> should throw typeof<System.ArgumentException>
        