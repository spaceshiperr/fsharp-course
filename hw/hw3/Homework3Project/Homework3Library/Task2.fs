namespace Homework3 

module Task2 = 

    type Tree<'a> =
    | Empty
    | Node of 'a * Tree<'a> * Tree<'a>
 
    let rec Map f binTree = 
        match binTree with
        | Empty -> Empty
        | Node(x, leftTree, rightTree) -> Node(f x, (Map f leftTree), (Map f rightTree))