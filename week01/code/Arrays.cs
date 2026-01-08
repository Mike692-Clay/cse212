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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        return []; // replace this return statement with your own
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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}


public static double[] MultiplesOf(double number, int length)
{
    // Step 1: Create an array of doubles with a size equal to 'length'
    // This array will store the multiples of the given number.
    double[] multiples = new double[length];

    // Step 2: Use a loop to fill the array.
    // The loop will run 'length' times, once for each multiple we need.
    for (int i = 0; i < length; i++)
    {
        // Step 3: Calculate the multiple for the current position.
        // Since array indexes start at 0, the first multiple should be:
        // number * (i + 1)
        multiples[i] = number * (i + 1);
    }

    // Step 4: Return the completed array of multiples.
    return multiples;



public static void RotateListRight(List<int> data, int amount)
{
    // Step 1: Understand the goal of the function.
    // We need to rotate the elements of the list to the right by 'amount' positions.
    // Rotating to the right means elements at the end of the list move to the front.

    // Step 2: Determine which elements will move.
    // The last 'amount' elements of the list will be moved to the beginning.
    // The remaining elements at the front will be shifted to the right.

    // Step 3: Create a temporary list to store the elements being moved.
    // This prevents overwriting values while rearranging the list.
    List<int> temp = new List<int>();

    // Step 4: Copy the last 'amount' elements from the original list into the temporary list.
    for (int i = data.Count - amount; i < data.Count; i++)
    {
        temp.Add(data[i]);
    }

    // Step 5: Remove the last 'amount' elements from the original list.
    data.RemoveRange(data.Count - amount, amount);

    // Step 6: Insert the elements from the temporary list at the beginning of the original list.
    data.InsertRange(0, temp);

    // Step 7: Since lists are modified directly, no value needs to be returned.
