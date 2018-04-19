namespace Homework5

open System

module PbView = 
    
    let printCommandList() = 
        printfn "Welcome to the Phonebook App! Choose one of the following:"
        printfn "Enter 1 to exit"
        printfn "Enter 2 to add profile"
        printfn "Enter 3 to find phone number by profile name"
        printfn "Enter 4 to find profile name by phone number"
        printfn "Enter 5 to print phonebook's content"
        printfn "Enter 6 to save data into a file"
        printfn "Enter 7 to read data from a file"

    let rec getCommand() = 
        printfn "\nPlease, enter the command number:"
        try 
            let command = int <| Console.ReadLine()
            if List.contains command [1..7] then command 
            else 
               raise (System.ArgumentOutOfRangeException null)
        with 
            | :? System.FormatException -> printfn "The command must be a number! Try again!"; getCommand()
            | :? System.ArgumentOutOfRangeException -> printfn "The number is out of range! Try again!"; getCommand()

    let rec getValue name = 
        printfn "Enter the %s:" name
        try 
            let value = Console.ReadLine()
            if value = "" then raise (System.ArgumentException null) else value
        with
            | :? System.ArgumentException -> printfn "The %s field should not be empty! Try again!" name; getValue name
    
    let getName() = getValue "name"
    let getPhone() = getValue "phone"    
    let getFilename() = getValue "filename"
    
    let printExit() = printfn "The application will be closed in 3 seconds.."
    let printFoundName name phone = printfn "Number %s belongs to %s" phone name
    let printFoundPhone name phone = printfn "%s's number is %s" name phone
    let printSuccessMessage name action = printfn "%s's data was successfully %s!" name action
    let printFailMessage message = printfn "The data couldn't be read since the file %s" message