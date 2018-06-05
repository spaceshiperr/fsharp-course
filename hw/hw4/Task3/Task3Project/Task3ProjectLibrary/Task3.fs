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
    /// Returns the list of free variables in the expression
    /// </summary>
    /// <param name="exp">Initial expression</param>
    let getFreeVariables exp = 
        let rec getFreeVariablesRec term variables = 
            match term with
            | Variable v -> v :: variables
            | Application(left, right) -> (getFreeVariablesRec left variables) @ (getFreeVariablesRec right variables)
            | Abstraction(v, f) -> (getFreeVariablesRec f variables) |> List.filter (fun x -> x <> v)
        getFreeVariablesRec exp []

    /// <summary>
    /// Generates a new name based on left and right terms of the application to avoid name conflicts
    /// </summary>
    /// <param name="left">Left term in the application</param>
    /// <param name="right">Right term in the application</param>
    let generateName left right = 
        let freeVariables = (getFreeVariables left) @ (getFreeVariables right)
        Set.toList (Set.ofList ['a'..'z'] - Set.ofList freeVariables) |> List.head

    /// <summary>
    /// Replaces all occurrences of x with substitutionExpression in initalExpression
    /// </summary>
    /// <param name="x">Variable of type Term that is being replaced</param>
    /// <param name="substitutionExpression">Lambda expression of type Term with which the replacement of x is made</param>
    /// <param name="initalExpression">Lambda expression of type Term in which the replacement is made</param>

    let rec substitute initialExpression v substitutionExpression =
        match initialExpression with
        | Variable x when x = v -> substitutionExpression
        | Variable x when x <> v -> initialExpression
        | Application (left, right) ->
            Application (substitute left v substitutionExpression, substitute right v substitutionExpression)
        | Abstraction (var, initialExpression) -> 
            match substitutionExpression with
            | Variable (_) when v = var -> initialExpression
            | _ when (not((getFreeVariables substitutionExpression) |> List.contains var) || (not((getFreeVariables initialExpression) |> List.contains v))) -> 
                Abstraction (var, substitute initialExpression v substitutionExpression)
            | _ -> 
                let newVar = generateName substitutionExpression initialExpression
                Abstraction (newVar, substitute (substitute substitutionExpression var (Variable (var))) v initialExpression)

    /// <summary>
    /// Beta-reduces the lambda expression
    /// </summary>
    /// <param name="exp">Expression to be beta-reduced</param>
    let rec evaluate exp = 
         match exp with
        | Variable v -> Variable v
        | Application (left, right) ->
            match left with
            | Abstraction (v, f) -> 
                evaluate (substitute f v right)
            | _ -> Application (evaluate left, evaluate right)
        | Abstraction (v, f) -> Abstraction(v, evaluate f)

