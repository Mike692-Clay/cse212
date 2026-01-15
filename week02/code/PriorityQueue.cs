public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.
    /// The node is always added to the back of the queue.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        _queue.Add(new PriorityItem(value, priority));
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        int highPriorityIndex = 0;

        // Scan the entire queue
        for (int index = 1; index < _queue.Count; index++)
        {
            // STRICT comparison preserves FIFO for ties
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // FIX: actually remove it
        return value;
    }

    // DO NOT MODIFY
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}


internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}

[TestMethod]
// Scenario: Enqueue items with different priorities
// Expected Result: Highest priority item is removed first
// Defect(s) Found: Last element not checked, item not removed
public void TestPriorityQueue_HighestPriority()
{
    var queue = new PriorityQueue();
    queue.Enqueue("A", 1);
    queue.Enqueue("B", 5);
    queue.Enqueue("C", 3);

    Assert.AreEqual("B", queue.Dequeue());
}

[TestMethod]
// Scenario: Multiple items share highest priority
// Expected Result: FIFO order preserved
// Defect(s) Found: >= comparison violated FIFO
public void TestPriorityQueue_FIFOForSamePriority()
{
    var queue = new PriorityQueue();
    queue.Enqueue("A", 5);
    queue.Enqueue("B", 5);
    queue.Enqueue("C", 3);

    Assert.AreEqual("A", queue.Dequeue());
    Assert.AreEqual("B", queue.Dequeue());
}

[TestMethod]
// Scenario: Ensure dequeued item is removed
// Expected Result: Queue shrinks properly
// Defect(s) Found: Item was never removed
public void TestPriorityQueue_ItemRemoved()
{
    var queue = new PriorityQueue();
    queue.Enqueue("A", 1);
    queue.Enqueue("B", 2);

    queue.Dequeue();
    Assert.AreEqual("A", queue.Dequeue());
}

[TestMethod]
// Scenario: Dequeue from empty queue
// Expected Result: InvalidOperationException with correct message
// Defect(s) Found: None
public void TestPriorityQueue_Empty()
{
    var queue = new PriorityQueue();

    try
    {
        queue.Dequeue();
        Assert.Fail("Exception should have been thrown.");
    }
    catch (InvalidOperationException e)
    {
        Assert.AreEqual("The queue is empty.", e.Message);
    }
}
