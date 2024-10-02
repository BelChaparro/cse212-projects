using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following string value and priority: Train (1), Velociraptor (8), Fire (3)
    // Expected Result: Velociraptor, Fire, Train
    // Defect(s) Found: The Dequeue doesn't remove & return the item with the highest priority.
    public void TestPriorityQueue_1()
    {
        var train = new PriorityItem("Train", 1);
        var dino = new PriorityItem("Velociraptor", 8);
        var fire = new PriorityItem("Fire", 3);

        PriorityItem[] expectedResult = [dino, fire, train];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(train.Value, train.Priority);
        priorityQueue.Enqueue(dino.Value, dino.Priority);
        priorityQueue.Enqueue(fire.Value, fire.Priority);

        int i = 0;
        while (priorityQueue.Count > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following string value and priority: House (1), Train (1), Velociraptor (8),
    // Fire (3), Tree (8)
    // Expected Result: Velociraptor, Tree, Fire, House, Train
    // Defect(s) Found: The Dequeue returns the item with the highest priority but not the first to enter the queue
    public void TestPriorityQueue_2()
    {
        var house = new PriorityItem("House", 1);
        var train = new PriorityItem("Train", 1);
        var dino = new PriorityItem("Velociraptor", 8);
        var fire = new PriorityItem("Fire", 3);
        var tree = new PriorityItem("Tree", 8);

        PriorityItem[] expectedResult = [dino, tree, fire, house, train];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(house.Value, house.Priority);
        priorityQueue.Enqueue(train.Value, train.Priority);
        priorityQueue.Enqueue(dino.Value, dino.Priority);
        priorityQueue.Enqueue(fire.Value, fire.Priority);
        priorityQueue.Enqueue(tree.Value, tree.Priority);

        int i = 0;
        while (priorityQueue.Count > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Try to get an item from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: The Dequeue InvalidOperationException message was different than the test.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}