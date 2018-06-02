namespace Homework5

module Task1 =

      /// <summary>
      /// Checks if the string has correcty nested brackets
      /// </summary>
      /// <param name="str">Input string</param>
      /// <param name="brackets">String of tree pairs of brackets</param>
      /// <returns>Returns true if the string is correct and false otherwise</returns>
      let isCorrectString(str, brackets) = 
        let splitList list = List.foldBack (fun x (left , right) -> x::right, left) list ([],[])
        let opening, closing = splitList <| List.ofSeq brackets
        let rec isCorrect stack list = 
            match list with
            | head :: tail when List.contains head opening -> isCorrect (head :: stack) tail
            | head :: tail when List.contains head closing -> if stack.IsEmpty || stack.Head <> List.item (List.findIndex (fun x -> x = head) closing) opening
                                                              then false else isCorrect stack.Tail tail
            | head :: tail -> isCorrect stack tail
            | [] -> stack.IsEmpty
        if String.length str  = 0 then raise (System.ArgumentException "Input string is empty")
        else isCorrect [] <| Seq.toList str
  
