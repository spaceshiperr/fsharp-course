namespace Homework5

module Task1 =

      /// <summary>
      /// Checks if the string has correcty nested brackets
      /// </summary>
      /// <param name="str">Input string</param>
      /// <param name="set1">Char tuple of first type of brackets</param>
      /// <param name="set2">Char tuple of second type of brackets</param>
      /// <param name="set3">Char tuple of third type of brackets</param>
      let isCorrectString (str, set1, set2, set3) = 
        let opening = [fst set1; fst set2; fst set3]
        let closing = [snd set1; snd set2; snd set3]
        let rec isCorrect stack list = 
            match list with
            | head :: tail when List.contains head opening -> isCorrect (head :: stack) tail
            | head :: tail when List.contains head closing -> if stack.IsEmpty || stack.Head <> List.item (List.findIndex (fun x -> x = head) closing) opening
                                                              then false else isCorrect stack.Tail tail
            | head :: tail -> isCorrect stack tail
            | [] -> stack.IsEmpty
        if String.length str  = 0 then raise (System.ArgumentException "Input string is empty")
        else isCorrect [] <| Seq.toList str
  
