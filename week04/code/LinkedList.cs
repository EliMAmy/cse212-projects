using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        //First we need to create a new node with the given value. 
        Node newNode = new(value);
        //If the list is empty, then point both head and tail to the new node.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        //If the list is not empty, then only tail will be affected.
        else
        {
            //Set the previous pointer of the new node to the current tail,
            newNode.Prev = _tail;
            //Set the next pointer of the current tail to the new node,
            _tail.Next = newNode;
            //Finally, update the tail to point to the new node.
            _tail = newNode;
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        // If the list has only one item in it, then set head and tail
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the tail will be affected
        else if (_tail is not null)
        {
            // Disconnect the second to last node from the last node, nulling out the next pointer of the second to last node
            _tail.Prev!.Next = null; 
            // Then set the tail to the second to last node, which is now the last node in the list
            _tail = _tail.Prev; 
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        //First we need to start at the head of the list and search for the node that contains 'value'.
        var curr = _head; // Start at the head of the list
        //Then we need to loop through the list until we find the node that contains 'value' or reach the end of the list.
        while (curr is not null)
        {
            //If we find the node that contains 'value', we need to check if it is the head, tail, or somewhere in the middle of the list.
            if (curr.Data == value)
            {
                // If the node to remove is the head, call RemoveHead
                if (curr == _head)
                {
                    RemoveHead();
                }
                // If the node to remove is the tail, call RemoveTail
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // Here we are removing a node that is neither the head nor the tail, so we need to reconnect the previous and next nodes to bypass the current node.
                else
                {
                    // Set the prev of the node after current to the node before current
                    curr.Next!.Prev = curr.Prev; 
                    // Set the next of the node before current to the node after current
                    curr.Prev!.Next = curr.Next; 
                    
                }
                // After removing the node, we can exit the function since we only want to remove the first occurrence of 'value'.
                return; 
            }
            // If we haven't found the node yet, move to the next node in the list.
            curr = curr.Next; 
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        Node? current = _head; // Start at the head of the list
        // Loop through the linked list until we reach the end (null)   
        
        while (current is not null)
        {
            // If the current node's data matches oldValue, replace it with newValue
            if (current.Data == oldValue)
            {
                current.Data = newValue;
            }
            // Move to the next node in the list to continue searching for oldValue
            current = current.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        // Start at the end since this is a backward iteration.
        var curr = _tail;
        // Loop through the linked list until we reach the beginning head of the list.
        while (curr is not null)
        {
            // Yield each item to the user
            yield return curr.Data; 
            // Move backward in the linked list
            curr = curr.Prev; 
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}