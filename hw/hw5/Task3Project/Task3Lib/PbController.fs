namespace Homework5

open Homework5.PbModel
open Homework5.PbView

module PbController = 
    
    let rec performAction phonebook : unit = 
        let command = getCommand()
        match command with 
        | 1 ->  printExit()
        | 2 ->  let name = getName()
                let newPhonebook = addProfile <| name <| getPhone() <| phonebook
                printSuccessMessage name "added"
                performAction newPhonebook
        | 3 ->  let name = getName()
                let phone = findByName <| name <| phonebook
                match phone with
                | Some(value) -> printFoundPhone name value.Phone
                | None -> printFoundPhone name "not found"
                performAction phonebook
        | 4 ->  let phone = getPhone()
                let name = findByPhone <| phone <| phonebook
                match name with
                | Some(value) -> printFoundName value.Name phone
                | None -> printFoundName "someone who isn't in the phonebook" phone
                performAction phonebook
        | 5 ->  print phonebook
                performAction phonebook
        | 6 ->  write <| getFilename() <| phonebook
                printSuccessMessage "File" "saved"
                performAction phonebook
        | 7 ->  let message = read <| getFilename()
                match message with
                | Some(newPhonebook) -> printSuccessMessage "File" "read"
                                        performAction newPhonebook
                | None -> printFailMessage
                          performAction phonebook
        | _ -> raise (System.ArgumentException "The command number is wrong")