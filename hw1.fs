// homework #1

// task 1.1

let fact x = 
    let rec calc x acc =
        if x <=1 then acc
        else calc (x-1) (acc*x)
    calc x 1

// task 1.2

let fib n = 
    let rec calc lt n n1 n2 = 
        if n <= 0 then lt
        else calc ((n1 + n2)::lt) (n - 1) n2 (n1 + n2)
    calc [1; 1] (n - 2) 1 1 |> List.rev

// task 1.3

let reverse lt = 
    let rec calc lt acc = 
        if lt = [] then acc
        else calc (List.tail lt) (List.head lt :: acc)
    calc lt []

// task 1.4

let powsof2 n m = 
    let rec calc m lt acc = 
        if m < 0 then lt
        else calc (m - 1) (acc * 2 :: lt) (acc * 2)
    calc m [] (pown 2 n-1) |> List.rev