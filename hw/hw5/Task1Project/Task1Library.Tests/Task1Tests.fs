namespace Homework5

open NUnit.Framework
open FsUnit
open Homework5.Task1

module Task1Tests = 

    let testStrings = 
            [
                TestCaseData("(hello) <world{!}>").Returns(true)
                TestCaseData("no brackets here").Returns(true)
                TestCaseData("").Returns(true)
                TestCaseData("(1+2)-<1-2>{").Returns(false)
                TestCaseData("(1+2)-<1-2>)").Returns(false)
                TestCaseData("{1+2(-}1-2)").Returns(false)
            ]
    
    [<TestCaseSource("testStrings")>]
    let ``isCorrectString of a string that might have 3 types of brackets tells if they are nested correctly`` str = 
        isCorrectString str
        