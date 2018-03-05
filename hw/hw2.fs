module hw2
    
    // task 2.1

    let multiplyDigits n = 
        let rec calc n acc = 
            match n with
            |0 -> if (n / 10) < 0 then acc else 0
            |_ -> calc (n / 10) (acc * (n % 10))
        calc n 1

    //task 2.2 

    let indexOf n lt = 
        let rec calc lt i = 
            match lt with 
            |[] -> None
            |h::t -> if h = n then Some(i)
                     else calc t (i + 1)
        calc lt 0

    // task 2.3

    let isPalindrome s = 
       match s with
       |""  -> true
       |_ -> List.forall (fun i -> s.[i] = s.[s.Length - i - 1]) [0..s.Length/2]

    // task 2.4

    let mergeLists left right = 
        let rec merge left right lt = 
            match left, right with 
            |[], [] -> lt
            |head::tail, [] | [], head::tail -> merge [] tail (head::lt)
            | leftHead::leftTail, rightHead::rightTail ->
                if leftHead < rightHead then merge leftTail right (leftHead::lt)
                else merge left rightTail (rightHead::lt)
        merge left right [] |> List.rev

    let divideList lt = 
        let rec divide left right lt = 
            match lt with 
            |[] -> (left, right)
            |[value] -> (value::left, right)
            |fst::snd::tail -> divide (fst::left) (snd::right) tail
        divide [] [] lt

    let rec mergeSort lt = 
        match lt with
        | [] -> []
        | [value] -> lt
        |_ -> let left = fst (divideList lt)
              let right = snd (divideList lt)
              mergeLists (mergeSort left) (mergeSort right)
