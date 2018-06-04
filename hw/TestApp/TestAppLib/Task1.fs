namespace TestApp

    module Task1 = 

        let averageSin list = 
            let rec sum list result = 
                match list with
                | [] -> result
                | head::tail -> sum tail <| result + sin head
            match list with 
            | [] -> raise (System.ArgumentException "Trying to find average sin of an empty list")
            | _ -> (sum list 0.0) / float(List.length list)
