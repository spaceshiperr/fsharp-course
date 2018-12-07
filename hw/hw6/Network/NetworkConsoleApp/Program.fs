open System
open NetworkLibrary.NetworkGeneratorModule
open NetworkLibrary.ComputerModule
open NetworkLibrary.NetworkModule

[<EntryPoint>]
let main argv =
    
    let n = 10
    let network = NetworkGenerator(n).generate()

    network.printAllConnections()
    network.infectComputers()
    network.Start()

    Console.ReadLine()
    0