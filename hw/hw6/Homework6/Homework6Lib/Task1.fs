namespace Homework6

open System
open System.Collections.Generic

module Task1 = 

    type Node<'x> = 
        | Node of 'x * Node<'x> * Node<'x> 
        | Empty

    type Tree<'x when 'x : comparison>() =    
        let mutable head = Empty
    
        let rec addRec node add =
            match node with
            | Node(x, left, right) when x < add -> Node(x, left, addRec right add)
            | Node(x, left, right) when x >= add -> Node(x, addRec left add, right)
            | Empty -> Node(add, Empty, Empty)
    
        let rec overbalance left node =
            match left with
            | Empty -> node
            | Node(x, left, right) -> Node(x, overbalance left node, right)

        let rec deleteRec node del =
            match node with
            | Node(x, left, right) when x < del -> Node(x, left, deleteRec right del)
            | Node(x, left, right) when x > del -> Node(x, deleteRec left del, right)
            | Node(x, Empty, Empty) when x = del -> Empty
            | Node(x, left, Empty) when x = del -> left
            | Node(x, left, right) when x = del -> overbalance right left
            | Empty -> Empty

        let rec ToListOfElements node =
            match node with
            | Empty -> []
            | Node(x, left, right) -> (ToListOfElements left) @ [x] @ (ToListOfElements right)
    
        interface IEnumerable<'x> with
            member this.GetEnumerator() = 
                ((new List<'x>(this.ToList())).GetEnumerator() :> Collections.IEnumerator)
            member this.GetEnumerator() =
                ((new List<'x>(this.ToList())).GetEnumerator() :> IEnumerator<'x>)
    
        member this.Add(add : 'x) = head <- addRec head add

        member this.Delete(del : 'x) = head <- deleteRec head del

        member x.ToList() = ToListOfElements head
