public static class Trees
{
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case
        if (first > last)
            return;

        int middle = (first + last) / 2;

        // Insert middle element
        bst.Insert(sortedNumbers[middle]);

        // Recurse left half
        InsertMiddle(sortedNumbers, first, middle - 1, bst);

        // Recurse right half
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}
