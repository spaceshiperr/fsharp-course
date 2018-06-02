namespace Homework7

open System

module Task1 = 

    type RoundBuilder(a: int) = 
            member this.Bind(x, f) = 
                x |> f
            member this.Return(x: double) = 
                Math.Round(x, a)
