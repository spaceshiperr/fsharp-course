namespace Homework3

module Task1 = 

    let countEvenNumbers1 = List.map (fun i -> 1 - (if i % 2 < 0 then - i % 2 else i % 2)) >>
                            List.fold (+) 0

    let countEvenNumbers2 = List.filter (fun i -> (if i % 2 < 0 then - i % 2 else i % 2) = 0) >>
                            List.fold (fun acc i -> acc + 1) 0 

    let countEvenNumbers3 = List.fold (fun acc i -> acc + 1 - (if i % 2 < 0 then - i % 2 else i % 2)) 0