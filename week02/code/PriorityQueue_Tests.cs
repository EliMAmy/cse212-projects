using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: This test case checks the behavior of the PriorityQueue when two items with different priorities are enqueued and then dequeued. It verifies that the item with the higher priority is returned first.
    // Expected Result: "B"
    // Defect(s) Found: Here we found the defect that the Dequeue method was not correctly removing the item with the highest priority from the queue. The original code was using ">=" instead of ">" in the comparison, which caused it to return the last item with the highest priority instead of the first one.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);       

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result);

    }

    [TestMethod]
    // Scenario: This case checks the behavior of the PriorityQueue when two items with different priorities are enqueued and then dequeued. It verifies that the item with the higher priority is returned first, followed by the item with the lower priority.
    // Expected Result: "B", "A"
    // Defect(s) Found: We realized that the Dequeue method was not correctly removing the item with the highest priority from the queue. 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
// The test number 3 is added to test the scenario where there are multiple items in the queue with the same priority. It checks if the items are dequeued in the order they were enqueued (FIFO) when they have the same priority.
//The expected result is that the items are dequeued in the order they were enqueued, which is "A" followed by "B".
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

//The test number 4 is added to test the scenario where there are multiple items in the queue with different priorities. It checks if the item with the highest priority is dequeued first, followed by the next highest priority item, and so on.
//The expected result is that the items are dequeued in the order of their priority.(7,3,1) which is "B" followed by "C" and then "A".
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 7);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }
}