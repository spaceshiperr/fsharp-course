namespace Homework5

open System
open System.IO
open System.Threading
open PbView
open PbController

module Main = 

    [<EntryPoint>]
    let main argv =
        printCommandList()
        let rec handle command = 
            match command with 
            | 1 -> printExit()
            | _ -> performAction command
                   handle <| getCommand()            
        handle <| getCommand()

        Thread.Sleep(3000)
        0
                
