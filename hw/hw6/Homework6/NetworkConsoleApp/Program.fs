open System
open NetworkLibrary.ComputerModule
open NetworkLibrary.NetworkModule

[<EntryPoint>]
let main argv =
   

    let generateNetwork compCount = 
        let list = []
        let random = new Random()
            
        let getRandomOS() =
            match random.Next(3) with
            | 0 -> Windows
            | 1 -> OSX
            | _ -> Linux

        let getRandomConnections(hub: Computer, list: list<Computer>, count: int) = 
            let getRandomItem list = List.item (random.Next(List.length list)) list
            let rec getNRandomItems list count result = 
                if count > 0
                then 
                    let item: Computer = getRandomItem list
                    if List.contains item result || item.ID = hub.ID || (List.contains item hub.Connections)
                    then getNRandomItems list count result
                    else getNRandomItems list (count - 1) <| (item :: result)
                else result
            getNRandomItems list count []

        let connect(hub: Computer, list: list<Computer>) = 
            List.map (fun c -> if List.contains c hub.Connections then c.Connections <- hub :: c.Connections; c else c) list
            
        let rec getUnconnectedComputers list count = 
            let OS = getRandomOS()
            let newComputer = Computer(List.length list, OS, [])
            if (count > 0)
            then getUnconnectedComputers (newComputer::list) (count - 1)
            else list
        
        let getConnectedComputers list = 
            let rec getComputers(list: list<Computer>, index: int) =
                if (index = list.Length) then list
                else 
                    let current = List.item index list
                    let connCount = random.Next(list.Length)
                    if (connCount > current.Connections.Length)
                    then current.Connections <- getRandomConnections(current, list, connCount - current.Connections.Length) @ current.Connections
                    else current.Connections <- current.Connections
                    let updatedList = connect(current, List.map (fun (c: Computer) -> if c.ID = current.ID then current else c) list)
                    getComputers(updatedList, index + 1)
            getComputers(list, 0)

        let unconnectedComputers = getUnconnectedComputers [] compCount
        getConnectedComputers unconnectedComputers
    
    let computers = generateNetwork 10
    for c in computers do
        printfn "Computer %i with connections" c.ID
        for conn in c.Connections do
            printfn "Computer %i" conn.ID
        printfn ""

    Network(computers).Start()
    0