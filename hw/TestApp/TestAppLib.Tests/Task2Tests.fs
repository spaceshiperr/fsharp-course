namespace TestApp

open TestApp.Task2
open NUnit.Framework
open FsUnit

module Task2Tests = 
    
    [<Test>]
    let ``minRootTipDistance of tree should equal 2`` () = 
        let tree = Tree(1, Tree(5, Tip(7), Tree(1, Tip(7), Tip(0))), Tree(1, Tip(5), Tip(0)))
        minRootTipDistance tree |> should equal 2

    [<Test>]
    let ``minRootTipDistance of tree should equal 1`` () = 
        let tree = Tree(-1, Tip(-5), Tip(0))
        minRootTipDistance tree |> should equal 1