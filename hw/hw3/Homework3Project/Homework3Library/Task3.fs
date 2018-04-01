namespace Homework3

module Task3 = 

    type Expression = 
        |Const of int
        |Plus of Expression * Expression 
        |Minus of Expression * Expression 
        |Product of Expression * Expression 
        |Division of Expression * Expression

    let rec evaluate (expression : Expression) = 
        match expression with
        |Const(n) -> n
        |Plus(n1, n2) -> evaluate n1 + evaluate n2
        |Minus(n1, n2) -> evaluate n1 - evaluate n2
        |Product(n1, n2) -> evaluate n1 * evaluate n2
        |Division(n1, n2) -> if (evaluate n2) = 0
                             then raise (System.DivideByZeroException "Trying to divide an integer number by zero")
                             else evaluate n1 / evaluate n2