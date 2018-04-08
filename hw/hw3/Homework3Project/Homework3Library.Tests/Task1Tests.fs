namespace Homework3 

open Homework3.Task1
open NUnit.Framework
open FsUnit

module Task1Tests = 

        let testData = 
            [
                TestCaseData([] : (int list)).Returns(0)
                TestCaseData([0; 1; 2; 3; 4; 5; 6]).Returns(4)
                TestCaseData([-1; 0; -8; 4; -2; 7]).Returns(4)
            ]
        
        [<TestCaseSource("testData")>]
        let ``countEvenNumbersByMap of integer list returns the total of even numbers`` data = 
            countEvenNumbersByMap data

        [<TestCaseSource("testData")>]
        let ``countEvenNumbersByFilter of integer list returns the total of even numbers`` data = 
            countEvenNumbersByFilter data

        [<TestCaseSource("testData")>]
        let ``countEvenNumbersByFold of integer list returns the total of even numbers`` data = 
            countEvenNumbersByFold data
