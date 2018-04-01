namespace Homework3

open System

module Task1 = 

    let countEvenNumbers1 = List.map (fun i -> 1 - Math.Abs(i % 2)) >> List.sum

    let countEvenNumbers2 = List.filter (fun i -> i % 2 = 0) >> List.length

    let countEvenNumbers3 = List.fold (fun acc i -> acc + 1 - Math.Abs(i % 2)) 0