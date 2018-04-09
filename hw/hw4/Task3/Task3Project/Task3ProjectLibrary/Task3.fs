namespace Homework4

module Task3 = 
    
    /// <summary>
    /// Defines the type for lambda term used in lambda expressions
    /// </summary>
    type Term<'a> = 
        | Variable of 'a
        | Application of Term<'a> * Term<'a>
        | Abstraction of 'a * Term<'a>

    /// <summary>
    /// Replaces all occurrences of x with e1 in e2
    /// </summary>
    /// <param name="x">Variable of type Term that is being replaced</param>
    /// <param name="exp1">Lambda expression of type Term with which the replacement of x is made</param>
    /// <param name="exp2">Lambda expression of type Term in which the replacement is made</param>
    let rec substitute x exp1 exp2 = 
        match exp2 with
        | Application (left, right) -> Application(substitute x exp1 left, substitute x exp1 right)
        | Abstraction (v, f) when v <> x -> Abstraction(v, substitute x exp1 f)
        | Variable (v) when x = v -> exp1
        | _ as term -> term

    /// <summary>
    /// Beta-reduces the lambda expression
    /// </summary>
    /// <param name="exp">Expression to be beta-reduced</param>
    let rec evaluate exp = 
        match exp with 
        | Application(Abstraction(v, f), right) -> substitute v right f
        | Application(left, right) -> Application(evaluate left, evaluate right)
        | Abstraction(v, f) -> Abstraction(v, evaluate f)
        | _ as term -> term