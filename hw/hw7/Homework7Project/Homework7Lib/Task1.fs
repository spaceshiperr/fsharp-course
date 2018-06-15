namespace Homework7

open System

module Task1 = 

    /// <summary>
    /// Workflow that computes the expression with given accuracy
    /// </summary>
    type RoundBuilder(accuracy: int) = 
        let isAccurate = accuracy >= 0 && accuracy <= 15
        member this.Bind(x: double, f) = 
            if isAccurate then f (Math.Round(x, accuracy))
            else None
        member this.Return(x: double) = 
            if isAccurate then Some <| Math.Round(x, accuracy)
            else None
