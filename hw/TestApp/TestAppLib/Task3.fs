namespace TestApp

    module Task3 = 

        type Stack<'a> () =
    
            let mutable list  = []
        
            member this.IsEmpty() =
                list.IsEmpty
            
            member this.Push x = 
                list <- x :: list
            
            member this.Pop() =
                match list with
                | [] -> raise (System.InvalidOperationException "Trying to do the pop operation for an empty stack!")
                | head:: tail -> list <- tail
                                 head

