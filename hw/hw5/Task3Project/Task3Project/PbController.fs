namespace Homework5

open Homework5.PbModel
open Homework5.PbView

module PbController = 
    
    let mutable phonebook = Phonebook()

    let performAction command = 
        match command with 
        | 1 -> phonebook.Clear()
        | 2 -> let name = getName()
               phonebook.Add <| name <| getPhone()
               printSuccessMessage name "added"
        | 3 -> let name = getName()
               let phone = phonebook.FindByName <| name
               match phone with
               | Some(value) -> printFoundPhone name value
               | None -> printFoundPhone name "not found"
        | 4 -> let phone = getPhone()
               let name = phonebook.FindByPhone <| phone
               match name with
               | Some(value) -> printFoundName value phone
               | None -> printFoundName "someone who isn't in the phonebook" phone
        | 5 -> phonebook.Print()
        | 6 -> phonebook.Write <| getFilename()
               printSuccessMessage "File" "saved"
        | 7 -> let message =  phonebook.Read <| getFilename()
               match message with
               | "read" -> printSuccessMessage "File" message
               | _ -> printFailMessage message
        | _ -> raise (System.ArgumentException "The command number is wrong")