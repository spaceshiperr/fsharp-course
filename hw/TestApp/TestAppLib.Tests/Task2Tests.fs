namespace TestApp

open TestApp.Task2
open NUnit.Framework
open FsUnit

module Task2Tests = 
    
    [<Test>]
    let ``minTreeDepth of a tree should equal 2`` () = 
        let tree = Tree(1, Tree(5, Tip(7), Tree(1, Tip(7), Tip(0))), Tree(1, Tip(5), Tip(0)))
        minTreeDepth tree |> should equal 2

    [<Test>]
    let ``minTreeDepth of a tree should equal 1`` () = 
        let tree = Tree(-1, Tip(-5), Tip(0))
        minTreeDepth tree |> should equal 1

    [<Test>]
    let ``minTreeDepth of a tree with root only should equal 0`` () = 
        let tree = Tip(5)
        minTreeDepth tree |> should equal 0