module hw2
    
    // task 2.1

    let multiplyDigits n = 
        let rec multiply result n = 
            match n with
            |0 -> 0
            |lastDigit when lastDigit / 10 = 0 -> result
            |_ -> multiply (result * (n % 10))  (n / 10)
        multiply 1 <| if n < 0 then -n else n

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
        |_ -> let left, right = splitList list
              mergeLists (mergeSort left) (mergeSort right)