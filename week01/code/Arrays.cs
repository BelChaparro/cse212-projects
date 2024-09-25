public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start

        // Create a fixed double array (with the received length) that will hold the multiples 
        double[] multiples = new double[length];

        // Create a loop that will run until the length given is reached.
        // Inside the loop, add all multiples of the given number to the multiples array by selecting 
        // an index in the array and placing the result of "number" * (i + 1).
        for (int i = 0; i < length; i++)
        {
            multiples[i] = (i + 1) * number;
        }

        // Return the final version of the multiples array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start

        // Check that the "data" List is not null or empty
        if (data == null || data.Count == 0)
        {
            return;
        }

        // Ensure that "amount" allows for rotation (No 0 or "amount" multiples)
        if (amount == 0 || amount % data.Count == 0)
        {
            return;
        }

        // Adjust "amount" to fit within data.Count (in case the given number exceeds data.Count)
        amount %= data.Count; // This will provide the remainder of the division, hence the real rotation

        // Store the fragment of the data to be rotated in a new List
        List<int> fragmentR = data.GetRange(data.Count - amount, amount);

        // Remove the fragment to be rotated from the original List to avoid duplication
        data.RemoveRange(data.Count - amount, amount);

        // Insert the fragment at the beginning of the original List
        data.InsertRange(0, fragmentR);
    }
}
