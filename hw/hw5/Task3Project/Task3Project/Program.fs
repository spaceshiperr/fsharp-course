namespace Homework5

open System.Threading
open PbView
open PbController

module Phonebook = 

   [<EntryPoint>] 
    let main argv = 
        printCommandList() 

        performAction []
 
        Thread.Sleep(3000) 
        0
