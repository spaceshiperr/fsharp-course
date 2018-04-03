namespace TestApp

    module Task2 = 

        type Tree<'a> =
            | Tree of 'a * Tree<'a> * Tree<'a>
            | Tip of 'a
        
        let minRootTipDistance tree = 
            let rec find tree distance list = 
                match tree with
                | Tree(_, left, right) -> min <| find left (distance + 1) list <| find right (distance + 1) list
                | Tip _ -> distance :: list
            List.min <| find tree 0 []