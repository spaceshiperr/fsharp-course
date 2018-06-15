namespace Homework5

open PbModel
open FsUnit
open NUnit.Framework
open System.IO

module PhoneBookTests = 

    [<Test>]
    let ``addProfile for the given name, phone and phonebook should return new phonebook``() = 
        let pb = [{Name = "def"; Phone = "456"}]
        let expected = [{Name = "abc"; Phone = "123"}; {Name = "def"; Phone = "456"}]
        let actual = addProfile "abc" "123" pb
        actual |> should equal expected

    [<Test>]
    let ``findByName for the given name present in the phonebook should return Some of the profile``() = 
        let pb = [{Name = "abc"; Phone = "123"}; {Name = "def"; Phone = "456"}]
        let expected = Some {Name = "def"; Phone = "456"}
        let actual = findByName "def" pb
        actual |> should equal expected

    [<Test>]
    let ``findByName for the given name not present in the phonebook should return None``() = 
        let pb = [{Name = "abc"; Phone = "123"}; {Name = "def"; Phone = "456"}]
        let expected = None
        let actual = findByName "ghost" pb
        actual |> should equal expected

    [<Test>]
    let ``findByPhone for the given phone present in the phonebook should return Some of the profile``() = 
        let pb = [{Name = "abc"; Phone = "123"}; {Name = "def"; Phone = "456"}]
        let expected = Some {Name = "abc"; Phone = "123"}
        let actual = findByPhone "123" pb
        actual |> should equal expected

    [<Test>]
    let ``findByPhone for the given phone not present in the phonebook should return None``() = 
        let pb = [{Name = "abc"; Phone = "123"}; {Name = "def"; Phone = "456"}]
        let expected = None
        let actual = findByPhone "404" pb
        actual |> should equal expected

    [<Test>]
    let ``read for an incorrect path should return None``() = 
        let expected = None
        let actual = read "not_found.json"
        actual |> should equal expected

    [<Test>]
    let ``read for an incorrect json file with the given path should return None``() =
        let expected = None
        let path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Content\incorrect_format.json");
        let actual = read path
        actual |> should equal expected

    [<Test>]
    let ``read for the correct json file with the given path should return Some of phonebook``() =
        let expected = Some [{Name = "Lazy Boi"; Phone = "3"}; {Name = "Good Boi"; Phone = "5"}]
        let path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Content\correct_format.json");
        let actual = read path
        actual |> should equal expected

    [<Test>]
    let ``Contents of the file after write phonebook should equal read for the same path``() =
        let pb = [{Name = "abc"; Phone = "123"}; {Name = "def"; Phone = "456"}]
        let path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Content\pb.json");
        write path pb
        let readPb = read path
        readPb.Value |> should equal pb