open System
open NetworkLibrary.NetworkGeneratorModule

[<EntryPoint>]
let main argv =
    
    let n = 100
    let network = NetworkGenerator(n).generate()
    network.printAllConnections()
    network.infectComputers()
    network.Start()

    Console.ReadLine()
    0