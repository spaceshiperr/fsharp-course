open System
open System.IO

    type Profile(name: string, phone: string) = 
        member val Name = name with get, set
        member val Phone = phone with get, set

    type Phonebook() = 
        let mutable mList : Profile list = []
        let add name phone = mList <- Profile(name, phone) :: mList
        let getPhone name = (List.find (fun (p: Profile) -> p.Name = name) mList).Phone
        let getName phone = (List.find (fun (p: Profile) -> p.Phone = phone) mList).Name
        let rec print (list: Profile list, cont) = 
            match list with
            | [] -> cont()
            | head :: tail -> print (tail, (fun () -> printfn "%s %s" head.Name head.Phone; cont()))
        let reader path =
            seq {
                use reader = new StreamReader(File.OpenRead(path))
                while not reader.EndOfStream do
                   yield reader.ReadLine() 
            }
        let read path = mList <- reader path |> Seq.toList |> List.collect (fun x -> Profile(((x.Split [|' '|]).GetValue(0)) :?> string, 
                                                                                             ((x.Split [|' '|]).GetValue(1)) :?> string) :: [] : Profile list)
        let writer path list : unit = 
            use writer = new StreamWriter(File.OpenWrite(path))
            let rec write (list : Profile list, cont) = 
                    match list with
                    | [] -> cont()
                    | head :: tail -> write (tail, (fun () -> writer.WriteLine(head.Name + " " + head.Phone); cont()))
            write (list, (fun () -> writer.WriteLine()))
        member pb.List = mList
        member pb.Add (name, phone) = add name phone
        member pb.FindByName name = getPhone name
        member pb.FindByPhone phone = getName phone
        member pb.Clear() = mList <- []
        member pb.Print() = print (mList, (fun () -> printfn "The end of the list"))
        member pb.Write path = writer path mList
        member pb.Read path = read path

    [<EntryPoint>]
    let main argv =

        printfn "Hello World from F#!"
        0 // return an integer exit code
