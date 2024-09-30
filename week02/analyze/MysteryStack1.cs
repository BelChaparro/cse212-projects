public static class MysteryStack1
{
    public static string Run(string text)
    {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}
// Pushes all letters in a text inside the stack.
// Then pops a letter from the stack and adds them to a string variable until the stack is empty.
// The resulting string is the original text inversed.