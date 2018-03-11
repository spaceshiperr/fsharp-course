module hw1

    // task 1.1

    let factorial x = 
        let rec recursiveFactorial x result =
            if x <= 1 then result
            else recursiveFactorial (x - 1) (result * x)
        recursiveFactorial x 1

    // task 1.2

    let getFibonacciList n = 
        let rec fibonacci list n n1 n2 = 
            if n <= 0 then list
            else fibonacci ((n1 + n2) :: list) (n - 1) n2 (n1 + n2)
        fibonacci [1; 1] (n - 2) 1 1 |> List.rev

    // task 1.3

    let reverseList list = 
        let rec reverse list reversedList = 
            if list = [] then reversedList
            else reverse (List.tail list) (List.head list :: reversedList)
        reverse list []

    // task 1.4

    let getPowersOfTwoList n m = 
        let rec addNext m list previous = 
            if m < 0 then list
            else addNext (m - 1) (previous * 2 :: list) (previous * 2)
        addNext m [] (pown 2 n - 1) |> List.rev