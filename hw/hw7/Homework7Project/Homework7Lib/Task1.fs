namespace Homework7

open System

module Task1 = 

    type RoundBuilder(accuracy: int) = 
            member this.Bind(x, f) = 
                x |> f
            member this.Return(x: double) = 
                match accuracy with
                | a when a < 0 || a > 15 -> None
                | _ -> Some <| Math.Round(x, accuracy)
