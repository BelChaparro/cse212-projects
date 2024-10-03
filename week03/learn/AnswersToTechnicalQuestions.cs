// Scenario: Write code to find the first time in a string when a letter is duplicated.
//
// 1. What are possible scenarios to consider? (Ex., think of a few strings you would want
// to try with your solution.)
// 2. What are some data structures that may be useful? And what would their performance be?
// 3. What are the boundary conditions that you should consider for this problem?
// 4. Outline a possible solution.

// 1) String where there is a duplicated letter: Apple
// String where there is not a duplicated letter: Car
// String with more than one duplicate letter: Street
// Empty string

// 2) Set, map.

// 3) Empty string, String with no duplicates, receive a different data type, String with 
// length of 1, String with all equal letters, String with lower and upper same letter.

// 4) 

public class LetterDuplicate
{
    public static void Run()
    {
        var apple = CheckFirstDuplicate("Apple");
        var car = CheckFirstDuplicate("Car");
        var street = CheckFirstDuplicate("Street");
        var caAuAC = CheckFirstDuplicate("caAuAC");
        var empty = CheckFirstDuplicate("");
        var one = CheckFirstDuplicate("C");
        var aaa = CheckFirstDuplicate("aaaaaaa");

        Console.WriteLine(apple); // p
        Console.WriteLine(car); // "No duplicates found!"
        Console.WriteLine(street); // e
        Console.WriteLine(caAuAC); // a
        Console.WriteLine(empty); // "The string is empty!"
        Console.WriteLine(one); // "The string is too short to compare characters!"
        Console.WriteLine(aaa); // a


    }

    public static string CheckFirstDuplicate(string sentence)
    {
        if (sentence.Length == 0)
        {
            return "The string is empty!";
        }
        else if (sentence.Length == 1)
        {
            return "The string is too short to compare characters!";
        }
        // First convert string to LowerCase:
        sentence = sentence.ToLower();

        var uniques = new HashSet<char>();

        foreach (char letter in sentence)
        {
            if (uniques.Contains(letter))
            {
                return $"First duplicate letter: {letter}";
            }
            else
            {
                uniques.Add(letter);
            }
        }
        return "No duplicates found!";
    }
}