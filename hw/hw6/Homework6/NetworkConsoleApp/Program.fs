open System
open NetworkLibrary.ComputerModule
open NetworkLibrary.NetworkModule

[<EntryPoint>]
let main argv =
    
    // проверить на число компонент связности в графе и привести к одной

    let generateNetwork compCount = 
        let list = []
        let random = new Random()
            
        let getRandomOS() =
            match random.Next(3) with
            | 0 -> Windows
            | 1 -> OSX
            | _ -> Linux

        let getRandomConnections hubID list count = 
            let getRandomItem list = List.item (random.Next(List.length list)) list
            let rec getNRandomItems list count result = 
                if count > 0
                then 
                    let item: Computer = getRandomItem list
                    if List.contains item result || item.ID = hubID
                    then getNRandomItems list count result
                    else getNRandomItems list (count - 1) <| (item :: result)
                else result
            getNRandomItems list count []
            
        let rec getUnconnectedComputers list count = 
            let OS = getRandomOS()
            let newComputer = Computer(List.length list, OS, [])
            if (count > 0)
            then getUnconnectedComputers (newComputer::list) (count - 1)
            else list
        
        let getConnectedComputers list = 
            let rec getComputers(unchangedList:list<Computer>, list: list<Computer>, result: list<Computer>) =
                if (List.isEmpty list) then result
                else 
                    let connCount = random.Next(List.length unchangedList)
                    let connections = getRandomConnections list.Head.ID unchangedList connCount
                    let computer = Computer(list.Head.ID, list.Head.OS, connections)
                    getComputers(unchangedList, list.Tail, (computer :: result))
            getComputers(list, list, [])

        let unconnectedComputers = getUnconnectedComputers [] compCount
        getConnectedComputers unconnectedComputers
    
    let computers = generateNetwork 10
    Network(computers).Start()
    0