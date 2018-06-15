namespace Homework7

open System

module Task2 = 
    
    /// <summary>
    /// Workflow that computes the expression with string operands
    /// </summary>
    type NumberBuilder() = 
        member this.Bind(x: string, f) = 
            let result, value = Int32.TryParse(x)
            match result with
            | false -> None
            | true -> f value
        member this.Return(x) = Some x
