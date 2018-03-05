module hw2
    
    // task 2.1

    let multiplyDigits n = 
        let rec calc n acc = 
            match n with
            |0 when acc = 1 -> 0
            |0 -> acc
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
