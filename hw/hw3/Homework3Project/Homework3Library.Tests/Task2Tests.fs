namespace Homework3

open Homework3.Task2
open NUnit.Framework
open FsUnit

module Task2Tests = 
    
    [<Test>]
    let ``Map of cubic function and an integer tree should return the tree with cube values`` () = 
        let Empty = Tree.Empty
        let tree = Node(3, Node(0, Node(2, Empty, Node(-5, Empty, Empty)), Node(-1, Empty, Empty)), Empty)
        let f = fun i -> i * i * i

        let expected = Node(27, Node(0, Node(8, Empty, Node(-125, Empty, Empty)), Node(-1, Empty, Empty)), Empty)

        let actual = Map f tree
        actual |> should equal expected

    [<Test>]
    let ``Map of identity function and a float tree should return the tree`` () = 
        let Empty = Tree.Empty
        let tree = Node(1.5, Node(0.4, Empty, Node(9.0, Empty, Empty)), Node(-0.6, Empty, Empty))
        let f = fun i -> i

        let expected = Node(1.5, Node(0.4, Empty, Node(9.0, Empty, Empty)), Node(-0.6, Empty, Empty))

        let actual = Map f tree
        actual |> should equal expected

    [<Test>]
    let ``Map of an identity function and an empty tree should return empty tree`` () = 
        let tree = Tree.Empty
        let f = fun i -> i

        let expected = Tree.Empty

        let actual = Map f tree
        actual |> should equal expected

    