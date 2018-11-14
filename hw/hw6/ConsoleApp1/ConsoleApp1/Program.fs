open System
open System.Collections
open System.Collections.Generic

type Node<'a> = 
    | Empty 
    | Node of 'a * Node<'a> * Node<'a>

type BinarycontainsTree<'a when 'a: comparison>(root: Node<'a>) = 
    
    let mutable root = root

    let rec contains node value = 
        match node with
        | Empty -> None
        | Node(x, left, right) -> if x = value then Some(node)
                                  else if value < x then contains left value
                                  else contains right value

    new() = BinarycontainsTree(Empty)

    member this.Root = root

    member this.Insert value = 
        let rec insert node value = 
            match node with 
            | Node(x, left, right) -> if value < x then Node(x, insert left value, right)
                                      else Node(x, left, insert right value)
            | Empty -> Node(value, Empty, Empty)
        root <- insert root value

    member this.Contains value = 
        let node = contains root value
        node <> None

    member this.Remove value = 
        let rec maxNode node = 
            match node with
            | Empty -> node
            | Node(_, _, Empty) -> node
            | Node(_, _, right) -> maxNode right

        let rec remove node value = 
            match node with
            | Empty -> failwith "The node is not found!"
            | Node(x, left, right) -> if value < x then Node(x, remove left value, right)
                                      elif value > x then Node(x, left, remove right value)
                                      elif left = Empty then right
                                      elif right = Empty then left
                                      else 
                                        let newValue = match maxNode left with
                                                       | Node(x, _, _) -> x
                                                       | Empty -> failwith "impossible scenario"
                                        let newLeft = remove left newValue
                                        Node(newValue, newLeft, right)
        root <- remove root value

    member this.ToList node =
        let rec toList node = 
            match node with
            | Empty -> []
            | Node(x, left, right) -> toList left @ x :: toList right
        toList node

    interface IEnumerable<'a> with
        member this.GetEnumerator() : IEnumerator<'a>=
            let list = this.ToList root
            (Seq.cast list).GetEnumerator() :> IEnumerator<'a>
        member this.GetEnumerator(): IEnumerator = 
            let list = this.ToList root
            (Seq.cast list).GetEnumerator() :> IEnumerator

[<EntryPoint>]
let main argv =
    let root = Node(5, Node(4, Empty, Empty), Node(8, Node(6, Empty, Empty), Empty))
    let tree = BinarycontainsTree(root)
    printfn "%A" <| tree.ToList tree.Root
    printfn "%b" <| tree.Contains 5
    Console.ReadLine()

    0 // return an integer exit code
