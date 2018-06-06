namespace Homework6

open NUnit.Framework
open FsUnit
open Homework6.Task1

module Task1Tests = 

    [<Test>]
    let ``ToList() for Tree<int> after Delete(1) should return empty list``() =
        let tree = new Tree<int>()
        tree.Delete(1)
        tree.ToList() |> should equal []

    [<Test>]
    let ``ToList() for Tree<int> after Add(1) and Delete(2) should return [1; 2]``() =
        let tree = new Tree<int>()
        tree.Add(1)
        tree.Add(2)
        tree.Delete(3)
        tree.ToList() |> should equal [1; 2]


    [<Test>]
    let ``ToList() for Tree<int> after pushing and deleteing nodes should return tree``() =
        let tree = new Tree<int>()
        tree.Add(5)
        tree.Add(1)
        tree.Add(7)
        tree.Add(10)
        tree.Add(2)
        tree.Delete(2)
        tree.Delete(7)
        tree.ToList() |> should equal [1; 5; 10]
