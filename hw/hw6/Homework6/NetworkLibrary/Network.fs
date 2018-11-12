namespace NetworkLibrary

module NetworkModule = 
    
    open ComputerModule
    open System

    type Network(computers: list<Computer>) = 

        let mutable computers = computers;
        
        member this.spreadInfection() = 
            let infect(computer: Computer) = 
                for connection in computer.Connections do
                    connection.Spead()
            for computer in computers do
                infect(computer)    
                
        member this.infectComputers() = 
            let random = new Random();
            for computer in computers do
                computer.Infect(random)

        member this.getInfected() = computers |> List.filter (fun x -> x.isInfected)

        member this.infectedTotal() = this.getInfected() |> List.length

        member this.SortByID computers = 
            List.sortBy (fun (c: Computer) -> c.ID) computers
            
        member this.printState() = 
            printf "Infected computers: "
            computers <- this.SortByID computers
            let infected = this.getInfected()
            for computer in infected do
                printf "%i " computer.ID
            printfn ""

        member this.printConnections(computer: Computer) = 
            printf "Computer %i is connected to: " computer.ID
            let sortedConnections = this.SortByID computer.Connections
            for connection in sortedConnections do
                printf "%i " connection.ID

        member this.printAllConnections() = 
            computers <- this.SortByID computers
            for computer in computers do
                this.printConnections(computer)
                printfn ""

        member this.Start() = 
            if (this.infectedTotal() <> computers.Length)
            then 
                this.printState()
                this.spreadInfection()
                this.Start()
            else
                this.printState()
                printfn "The network has been shut down."