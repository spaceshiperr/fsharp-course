namespace TestApp

    module Task1 = 

        let averageSin list = 
            let rec average list sum = 
                match list with
                | [] -> sum
                | head::tail -> average tail <| sum + sin head
            match list with 
            | [] -> raise (System.ArgumentNullException "Trying to find average sin of an empty list")
            | _ -> (average list 0.0) / float(List.length list)
