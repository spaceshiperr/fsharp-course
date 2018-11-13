type Node<'a> = 
    | Empty 
    | Node of 'a * Node<'a> * Node<'a>

type BinarySearchTree(root: Node<'a>) = 
    
    let mutable root = root

    member this.Insert value = 
        let rec insert node value = 
            match node with 
            | Node(x, left, right) -> if value < x then Node(x, insert left value, right)
                                      else Node(x, left, insert right value)
            | Empty -> Node(value, Empty, Empty)
        root <- insert root value

    member this.Search value = 
        let rec search node value = 
            match node with
            | Empty -> None
            | Node(x, left, right) -> if x = value then Some(node)
                                      else if value < x then search left value
                                      else search right value
        let node = search root value
        node <> None

    //member this.Remove 

[<EntryPoint>]
let main argv =
    //printfn "Hello World from F#!"
    0 // return an integer exit code
