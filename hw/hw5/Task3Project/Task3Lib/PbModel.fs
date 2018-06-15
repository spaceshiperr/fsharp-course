namespace Homework5

open System.IO
open Newtonsoft.Json

module PbModel = 

    type Profile = 
        { 
            Name : string
            Phone : string 
        }

    let addProfile name phone phonebook = { Name = name; Phone = phone } :: phonebook

    let findByName name = List.tryFind (fun profile -> profile.Name = name) 

    let findByPhone phone = List.tryFind (fun profile -> profile.Phone = phone)

    let print = List.iter (fun profile -> printfn "Name: %s; Phone: %s" profile.Name profile.Phone)

    let write path phonebook = 
        use writer = new StreamWriter(File.OpenWrite(path))
        let serializer = JsonSerializer();
        serializer.Serialize(writer, phonebook);

    let read path = 
        try
            use reader = new StreamReader(File.OpenRead(path))
            use jsonReader = new JsonTextReader(reader)
            let serializer = JsonSerializer()
            Some(serializer.Deserialize<Profile list>(jsonReader))
        with
            | :? FileNotFoundException -> None
            | :? JsonReaderException -> None