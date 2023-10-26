using System.Collections;

namespace prove_07;

/// <summary>
/// Implements a basic doubly linked list of integers
/// </summary>
public class LinkedList : IEnumerable<int> {
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Adds a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void AddFirst(int value) {
        // Create new node
        Node newNode = new Node(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null) {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Adds a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void AddLast(int value) {
        // TODO Problem 1
        //create a new node named newNode
        var newNode = new Node(value);
        //check unique situation if linked list is empty past what you added.
        //if it is, make the newNode the head and the tail.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        //if the list is not empty, then only tail will be affected.
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
            
        }
        
    }


    /// <summary>
    /// Removes the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveFirst() {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail) {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null) {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Removes the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveLast() {
        // TODO Problem 2
        //check if linked list has only one item in it, if so set _head and _tail to null
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        //if it has more than one item in the list only the _tail gets effected(removed) and the secondLast item becomes new _tail.
        //create new variable representing the second to last item in the linked list.
        var secondLast = _tail.Prev;//sets to the node before _tail
        secondLast.Next = null;//underlined yellow squigly means it can be null but it cautions against this (i think)
                               //no action is needed unless this bugs you.
        _tail = secondLast;
    }

    /// <summary>
    /// Adds 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void AddAfter(int value, int newValue) {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null) {
            if (curr.Data == value) {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail) {
                    AddLast(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else {
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
    /// Removes the first node that contains 'value'.
    /// </summary>
    public void Remove(int value) {
        // TODO Problem 3
        //create node to keep track of which node you are at and which one you started from
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                
                //____________________________
                if (curr.Prev == null)// *******This one works now, but next and #4 does notWHY DOES THIS NOT GET RID OF THE FIRST THING IN THE linked List?????**********
                                        // **** also, this is a copy from github but one seperate form the first and this has no github connection. WHy?
                                        // I downloaded a zip file of it from the github and then put that in a folder so i could run just the file needed so I could use the green play button.
                                        //I had one directly from github I could push but that one still could not play the green button so I did this but now it can't push because it is seperate.
                                        //I was going to just copy the text from each file and past it in the one I can push but there must be a better way.
                {
                    curr.Next.Prev = null;
                    _head = curr.Next;
                    curr = null;//?
                    // Console.WriteLine("at front of the list worked");
                    return;
                }

                if (curr.Next == null)
                {
                    curr.Prev.Next = null;
                    _tail = curr.Prev;
                    curr = null;
                    // Console.WriteLine("at end of the list worked");
                    return;
                }
                
                else
                {
                    curr.Prev.Next = curr.Next;//sets the curr Node's previous' next value to curr value's next node
                    curr.Next.Prev = curr.Prev;//sets curr Node's next node's previous value to curr Node's previous node (opposite of the one above)
                    curr = null;//deletes the current Node that haas the value to be deleted.
                    // Console.WriteLine("if statement happened");
                }
                
                
                

                return;//this exits the function.
            }

            curr = curr.Next;//go to the next node to find the one with the right value

        }
        
        
    }

    /// <summary>
    /// Searches for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue) {//**********?????????? look down until you find next ** and ??
        // TODO Problem 4
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }
            curr = curr.Next;//go to the next node to find the one with the right value
        }
       
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator() {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null) {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse() {
        // TODO Problem 5
        var curr = _tail; // Start at the beginning since this is a forward iteration.
        while (curr is not null) {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Prev; // Go forward in the linked list
        }
        //yield return 0; // replace this line with the correct yield return statement(s)
    }

    public override string ToString() {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }
}