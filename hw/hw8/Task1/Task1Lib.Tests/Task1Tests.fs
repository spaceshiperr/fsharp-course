namespace Homework8

open NUnit.Framework
open FsUnit
open Homework8.Task1

module Task1Tests = 
   
    [<Test>]
    let ``Test for http://spisok.math.spbu.ru``() = 
        let url = "http://spisok.math.spbu.ru"
        let expected = [("http://spisok.math.spbu.ru", 4737)]
        let actual = getList(url)
        expected |> should equal actual

           
    [<Test>]
    let ``Test for http://se.math.spbu.ru/SE``() = 
        let url = "http://se.math.spbu.ru/SE"
        let expected = [("http://se.math.spbu.ru/SE", 51153); 
                        ("http://se.math.spbu.ru/SE", 56491);
                        ("http://se.math.spbu.ru/SE", 2113);
                        ("http://se.math.spbu.ru/SE", 4650);
                        ("http://se.math.spbu.ru/SE", 3017);
                        ("http://se.math.spbu.ru/SE", 2234);
                        ("http://se.math.spbu.ru/SE", 23081);
                        ("http://se.math.spbu.ru/SE", 12379);
                        ("http://se.math.spbu.ru/SE", 23081)]
        let actual = getList(url)
        expected |> should equal actual

           
    [<Test>]
    let ``Test for 123``() = 
        let url ="123"
        let expected = []
        let actual = getList(url)
        expected |> should equal actual
        
        