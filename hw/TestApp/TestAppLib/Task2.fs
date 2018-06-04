namespace TestApp

    module Task2 = 

        type Tree<'a> =
            | Tree of 'a * Tree<'a> * Tree<'a>
            | Tip of 'a
        
        let minTreeDepth tree = 
            let rec find tree depth = 
                match tree with
                | Tree(_, left, right) -> min <| find left (depth + 1) <| find right (depth + 1)
                | Tip _ -> depth
            find tree 0