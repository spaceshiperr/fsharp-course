namespace Homework5

module Task1 =

      /// <summary>
      /// Checks if the string has correcty nested brackets
      /// </summary>
      /// <param name="str">Input string</param>
      /// <returns>Returns true if the string is correct and false otherwise</returns>
      let isCorrectString (str : string) = 
        let opening = ['{'; '('; '<']
        let closing = ['}'; ')'; '>']
        let rec isCorrect stack list = 
            match list with
            | head :: tail when List.contains head opening -> isCorrect (head :: stack) tail
            | head :: tail when List.contains head closing -> if stack.IsEmpty || stack.Head <> List.item (List.findIndex (fun x -> x = head) closing) opening
                                                              then false else isCorrect stack.Tail tail
            | head :: tail -> isCorrect stack tail
            | [] -> stack.IsEmpty
        let bracketList = Seq.toList str |> List.filter (fun x -> List.contains x opening || List.contains x closing)
        isCorrect [] bracketList