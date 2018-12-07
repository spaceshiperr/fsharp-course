namespace BSTTests

open NUnit.Framework
open FsUnit
open BSTLibrary.BST

module UnitTests = 
    open System
    open System.Collections.ObjectModel

    [<Test>]
    let ``create BinarySearchTree<int> with one root node returns tree with this root``() = 
        let root = Node(1, Empty, Empty)
        let tree = BinarySearchTree<int>(root)
        tree.Root |> should equal root

    [<Test>]
    let ``insert nodes into the tree should link them to the root``() = 
        let tree = BinarySearchTree()
        tree.Insert(5)
        tree.Insert(3)
        tree.Insert(2)
        tree.Insert(7)
        tree.Insert(8)
        let root = Node(5, Node(3, Node(2, Empty, Empty), Empty), Node(7, Empty, Node(8, Empty, Empty)))
        tree.Root |> should equal root

    [<Test>]
    let ``contains should return true for nodes present in the tree``() = 
        let tree = BinarySearchTree(Node(6, Node(3, Empty, Empty), Node(9, Empty, Empty)))
        tree.Contains 3 |> should equal true

    [<Test>]
    let ``contains should return false for nodes present in the tree``() = 
        let tree = BinarySearchTree(Node(6, Node(3, Empty, Empty), Node(9, Empty, Empty)))
        tree.Contains 12 |> should equal false

    [<Test>]
    let ``contains after removing non-root node from the tree should return false``() = 
        let tree = BinarySearchTree()
        tree.Insert(1)
        tree.Insert(2)
        tree.Insert(0)
        tree.Remove(0)
        tree.Remove(2)
        (tree.Contains 2 || tree.Contains 0) |> should equal false

    [<Test>]
    let ``IsEmpty after removing root node should return true``() = 
        let tree = BinarySearchTree(Node("root", Empty, Empty))
        tree.Remove  "root"
        tree.IsEmpty |> should equal true
    
    [<Test>]
    let ``remove for empty tree should throw InvalidOperationException``() = 
        let tree = BinarySearchTree()
        (fun () -> tree.Remove 5 |> ignore) |> should  throw typeof<System.InvalidOperationException>

    [<Test>]
    let ``remove for nonpresent node should throw ArgumentException``() = 
        let tree = BinarySearchTree<double>()
        tree.Insert(0.1)
        tree.Insert(0.9)
        (fun () -> tree.Remove 0.5 |> ignore) |> should throw typeof<System.ArgumentException>

    [<Test>]
    let ``toList should turn tree into list by inorder traversal``() = 
        let tree = BinarySearchTree()
        tree.Insert(5)
        tree.Insert(3)
        tree.Insert(10)
        tree.Insert(8)
        tree.Insert(9)
        let actual = tree.ToList()
        let expected = [3; 5; 8; 9; 10]
        actual |> should equal expected

    [<Test>]
    let ``tree node values after iteration should equal reversed toList result``() = 
        let tree = BinarySearchTree(Node(5, Node(2, Node(1, Empty, Empty), Node(3, Empty, Empty)), Node(9, Empty, Empty)))
        let mutable list = []
        for node in tree do
            list <- node :: list
        let actual = List.rev list
        let expected = tree.ToList()
        CollectionAssert.AreEqual(actual, expected)
        