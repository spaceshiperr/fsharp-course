namespace Homework3

open System

module Task4 = 

    let isPrime (n:bigint) =
            let upperBound = bigint(Math.Sqrt(float(n)))
            let rec check i =
                i > upperBound || (n % i <> 0I && check (i + 1I))
            check 2I 

    let primes =
          Seq.initInfinite (fun i -> i + 2)
          |> Seq.map (fun i -> bigint(i))
          |> Seq.filter isPrime