namespace Homework5

module Task2Tests = 

    open NUnit.Framework
    open FsCheck
    open Homework5.Task2

    [<Test>]
    let ``func returns the same result as func'1 for any given x and list`` () =      
        let property x list =  func x list = func'1 x list
        Check.QuickThrowOnFailure property

    [<Test>]
    let ``func'1 returns the same result as func'2 for any given x and list`` () =   
        let property x list =  func'1 x list = func'2 x list
        Check.QuickThrowOnFailure property

    [<Test>]
    let ``func'2 returns the same result as func'3 for any given x and list`` () =   
        let property x list =  func'2 x list = func'3 x list
        Check.QuickThrowOnFailure property

    [<Test>]
    let ``func'3 returns the same result as func'4 for any given x and list`` () =   
        let property x list =  func'3 x list = func'4 x list
        Check.QuickThrowOnFailure property