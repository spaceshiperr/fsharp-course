namespace NetworkLibrary

module ComputerModule =

    open System
    
    type OS = Windows | OSX | Linux

    type Computer(ID: int, OS: OS, connections: list<Computer>) = 
        
        member val isInfected = false with get, set

        member val Connections = connections with get, set

        member this.ID = ID
        
        member this.OS = OS

        //member this.Connections = connections

        member this.Probability = match OS with
                                  | Windows -> 0.5
                                  | OSX -> 0.3
                                  | Linux -> 0.2

        member this.Infect(random: Random) = 
            this.isInfected <- (random.NextDouble() >= this.Probability)

        member this.Spead() = 
            this.isInfected <- true

