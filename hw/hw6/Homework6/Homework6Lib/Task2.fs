namespace Homework6

open System

module Task2 = 

    type System = Windows | Linux | MacOS

    type OS() =
        let mutable pWindows = 0.0 
        let mutable pLinux = 0.0 
        let mutable pMacOS = 0.0 
    
        member this.SetInfectionProbability pForWindows pForLinux pForMacOS =
            pWindows <- pForWindows
            pLinux <- pForLinux
            pMacOS <- pForMacOS

        member this.GetInfectionProbability(os) = 
            match os with
            | System.Windows -> pWindows
            | System.Linux -> pLinux
            | System.MacOS -> pMacOS
    
    type Computer(system : System, infected : bool) =
        member val os = system with get, set

        member val isInfected = infected with get, set

        member val isInfectedToday = true with get, set

    type Lan(newComputers : array<Computer>, newAdMatrix : bool[,], newOS : OS) =
        let mutable computers = newComputers
        let mutable adMatrix = newAdMatrix
        let rand = new Random()
        let os = newOS
        do
            if (computers.Length <> Array2D.length1 adMatrix || computers.Length <> Array2D.length2 adMatrix)
            then 
                raise (ArgumentException("Length of computers array disagree with length of matrix!"))

        let isInfectedNow compCount =
            rand.Next(100) <= int (100.0 * os.GetInfectionProbability(computers.[compCount].os))

        let infectAllNeighbors compCount =
            for neighborCount in 0..computers.Length - 1 do        
                if (adMatrix.[compCount, neighborCount] = true && not computers.[neighborCount].isInfected && (isInfectedNow neighborCount))
                then
                    computers.[neighborCount].isInfected <- true
                    computers.[neighborCount].isInfectedToday <- true

        let next() =
            for i in 0..computers.Length - 1 do
                if (computers.[i].isInfected = true && computers.[i].isInfectedToday = false)
                then
                    infectAllNeighbors i 

        let nextBegin() =
            for comp in computers do
                comp.isInfectedToday <- false

        member this.Next() =
            nextBegin() 
            next()
    
        member this.Computers
            with get() = computers