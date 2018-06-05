namespace Homework8

open System.Text.RegularExpressions
open System.Net
open System.IO

module Task1 = 
    
    type ErrorHandler =
        | Success of string
        | Error of string 
    
    let read (url) =
                    
        let readPage (urlRef : string) = 
            async {
                try
                    let request = WebRequest.Create(urlRef)
                    use! response = request.AsyncGetResponse()
                    use stream = response.GetResponseStream()
                    use reader = new StreamReader(stream)
                    let html = reader.ReadToEnd()
                    return (url, Success(html))
                with 
                    | ex -> return (url, Error(ex.Message))
            }
        
        let regex = Regex("<a href=\"(https?://[^\"]+)\">", RegexOptions.Compiled)
        let mainPage = readPage(url) |> Async.RunSynchronously
        
        match mainPage with
        | (url', Success(html)) ->
            let matches = regex.Matches(html)
            let toRun = seq { for m in matches do 
                                yield readPage m.Groups.[1].Value } 
            mainPage :: (Async.Parallel toRun |> Async.RunSynchronously |> Array.toList)
        | _ -> [mainPage]
        
    let getList (url) =
        let results = read url
        let mutable lengthList = []
        for res in results do
            match res with
            | (_url, Success(doc)) ->
                lengthList <- (_url, doc.Length) :: lengthList
            | _ -> ()
        lengthList
       
    let printData (url) =
        let results = getList url
        for (url', count) in results do
            printfn "%s - %d" url' count