namespace NetworkLibraryTests

open NUnit.Framework
open FsUnit
open NetworkLibrary

open ComputerModule
open NetworkModule
open NetworkGeneratorModule

module NetworkTests = 

    let network = 
        let c1 = Computer(1, Linux, [])
        let c11 = Computer(11, Windows, [])
        let c12 = Computer(12, OSX, [])
        let c111 = Computer(111, Linux, [])
        let c121 = Computer(121, Windows, [])
        let c122 = Computer(122, OSX, [])
        c1.Connections <- [c11; c12]
        c1.isInfected <- true
        c11.Connections <- [c11; c111]
        c12.Connections <- [c11; c121; c122]
        c111.Connections <- [c11]
        c121.Connections <- [c12]
        c122.Connections <- [c12]
        let computers = [c1; c11; c12; c111; c121; c122]
        Network(computers)

    [<Test>]
    let ``start on the local network``() = 
        network.Start()
        let expected = network.getComputers().Length
        let actual = network.infectedTotal()
        actual |> should equal expected

    [<Test>]
    let ``start on the generated network``() = 
        let genNetwork = NetworkGenerator(10).generate()
        genNetwork.infectComputers()
        genNetwork.Start()
        let expected = genNetwork.getComputers().Length
        let actual = genNetwork.infectedTotal()
        actual |> should equal expected


