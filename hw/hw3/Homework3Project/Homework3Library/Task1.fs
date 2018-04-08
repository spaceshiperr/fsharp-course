namespace Homework3

open System

module Task1 = 

    let countEvenNumbersByMap = List.map (fun i -> 1 - abs i % 2) >> List.sum

    let countEvenNumbersByFilter = List.filter (fun i -> i % 2 = 0) >> List.length

    let countEvenNumbersByFold = List.fold (fun acc i -> acc + 1 - abs i % 2) 0