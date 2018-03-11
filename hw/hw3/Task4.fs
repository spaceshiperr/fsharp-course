namespace Homework3

module Task4 = 

    let isPrime (n:bigint) =
            let rec check i =
                i > n/2I || (n % i <> 0I && check (i + 1I))
            check 2I

    let primes =
          Seq.initInfinite (fun i -> i + 2)
          |> Seq.map (fun i -> bigint(i))
          |> Seq.filter isPrime