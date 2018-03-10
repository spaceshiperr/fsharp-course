module hw2
    
    // task 2.1

    let multiplyDigits n = 
        let rec multiply n result = 
            match n with
            |0 -> if (n / 10) < 0 then result else 0
            |_ -> multiply (n / 10) (result * (n % 10))
        multiply n 1

    // task 2.2 

    let indexOf n list = 
        let rec getIndex list i = 
            match list with 
            |[] -> None
            |head::tail -> if head = n then Some(i)
                            else getIndex tail (i + 1)
        getIndex list 0

    // task 2.3

    let isPalindrome s = 
       match s with
       |""  -> true
       |_ -> List.forall (fun i -> s.[i] = s.[s.Length - i - 1]) [0 .. s.Length / 2]

    // task 2.4

    let mergeLists left right = 
        let rec merge left right list = 
            match left, right with 
            |[], [] -> list
            |head::tail, [] | [], head::tail -> merge [] tail (head::list)
            |leftHead::leftTail, rightHead::rightTail ->
                if leftHead < rightHead then merge leftTail right (leftHead::list)
                else merge left rightTail (rightHead::list)
        merge left right [] |> List.rev

    let splitList list = 
        let rec split left right list = 
            match list with 
            |[] -> (left, right)
            |[value] -> (value::left, right)
            |firstNumber::secondNumber::tail -> 
                split (firstNumber::left) (secondNumber::right) tail
        split [] [] list

    let rec mergeSort list = 
        match list with
        | [] -> []
        | [value] -> list
        |_ -> let left = fst (splitList list)
              let right = snd (splitList list)
              mergeLists (mergeSort left) (mergeSort right)