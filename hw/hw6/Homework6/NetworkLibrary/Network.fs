namespace NetworkLibrary

module NetworkModule = 
    
    open ComputerModule
    open System

    type Network(computers: list<Computer>) = 

        let spreadInfection() = 
            let infect(computer: Computer) = 
                for connection in computer.Connections do
                    connection.Spead()
            for computer in computers do
                infect(computer)    
                
        let infectComputers() = 
            let random = new Random();
            for computer in computers do
                computer.Infect(random)

        let getInfected() = computers |> List.filter (fun x -> x.isInfected)

        let mutable computers = computers;

        member this.infectedTotal() = getInfected() |> List.length

        member this.printState() = 
            let infected = getInfected()
            for computer in infected do
                printfn "Computer %i is infected" computer.ID
            printfn "\n"

        member this.Start() = 
            let infectedCount = this.infectedTotal()
            if (infectedCount = 0)
            then infectComputers()
                 this.Start()
            else if (infectedCount <> computers.Length)
            then 
                this.printState()
                spreadInfection()
                this.Start()