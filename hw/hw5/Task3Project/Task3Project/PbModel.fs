namespace Homework5

open System.IO
open System.Collections.Generic
open Newtonsoft.Json

module PbModel = 


    type Profile(name: string, phone: string) = 
        member val Name = name with get, set
        member val Phone = phone with get, set

    type Phonebook() = 
        let mutable mList : Profile list = []
        let add name phone = mList <- Profile(name, phone) :: mList
        let getPhone name = try 
                                Some <| (List.find (fun (p: Profile) -> p.Name = name) mList).Phone
                            with 
                                | :? KeyNotFoundException -> None
        let getName phone = try
                                Some <| (List.find (fun (p: Profile) -> p.Phone = phone) mList).Name
                            with 
                                | :? KeyNotFoundException -> None
        let rec print (list: Profile list, cont) = 
            match list with
            | [] -> cont()
            | head :: tail -> print (tail, (fun () -> printfn "Name: %s; Phone: %s" head.Name head.Phone; cont()))
        let write path = 
            use writer = new StreamWriter(File.OpenWrite(path))
            let serializer = JsonSerializer();
            serializer.Serialize(writer, mList);
        let read path =
            try
                use reader = new StreamReader(File.OpenRead(path))
                use jsonReader = new JsonTextReader(reader)
                let serializer = JsonSerializer()
                mList <- serializer.Deserialize<Profile list>(jsonReader);
                true
            with
                | :? FileNotFoundException -> false
        member pb.Add name phone = add name phone
        member pb.FindByName name = getPhone name
        member pb.FindByPhone phone = getName phone
        member pb.Clear() = mList <- []
        member pb.Print() = print (mList, (fun () -> printfn "The end of the list."))
        member pb.Write path = write path
        member pb.Read path = read path