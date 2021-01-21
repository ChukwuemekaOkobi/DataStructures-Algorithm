using System;

namespace LinkedList
{
    /// <summary>
    /// Implementation of a LinkedList
    /// </summary>
    public class LinkedList
    {
        //Reference to the first element in the list
        public Node Head;

        public void PrintAll()
        {
            var hold = Head;
            int i = 0;
            while (hold != null)
            {
                Console.WriteLine($"value {++i} is {hold.Value}");
                hold = hold.Next;
            }
        }

        //Add to the Last Value the sequence
        public void AddLast(int value)
        {
            //check is the first element is its empty
            if (Head is null)
            {
                Head = new Node(value);
                Last = Head; //sets the last element as the first
            }
            else
            {
                //add a new node to the last element; 
                Last.Next = new Node(value);
                Last = Last.Next;
            }
            Count++;
        }

        //add to the top of the list
        public void AddFirst(int value)
        {
            //Checks if the first element is empty
            if (Head is null)
            {
                Head = new Node(value);
                Last = Head;
            }
            else
            {
                var hold = Head; //hold the first element

                Head = new Node(value) //sets the first element to the new element
                {
                    Next = hold
                };
            }

            Count++;
        }
     
        
        public void RemoveLast()
        {
            Last = Head;

            if(Last is null)
            {
                throw new NullReferenceException("Cannot remove Last sequence in a empty list");
            }

            //track and find the last element in the sequence
            while (Last.Next != null)
            {
                Last = Last.Next;

                //checks to get the last element
                if (Last.Next.Next == null)
                {
                    Last.Next = null;
                    Count--;
                }
            }

        }

        public void RemoveFirst()
        {
            var hold = Head;  // hold the first elemene

            if(hold is null)
            {
                throw new NullReferenceException("Cannot removed first value in an empty list");  
            }

            else 
            {
                Head = hold.Next; 
                Count--;
            }

        }
        
        public void RemoveNode(Node node)
        {
            if(node is null)
            {
                throw new NullReferenceException("Node cannot be null");
            }
            if(Head is null)
            {
                throw new NullReferenceException("Cannot remove node of an empty list");
            }

            var hold = Head;
            if(hold == node)
            {
                RemoveFirst();
                return;
            }
            var found = false;
            while (hold.Next != null)
            {
               Last = hold;

                if(hold.Next == node )
                {
                    var next = node.Next;
                    Last.Next = next;

                    found = true;
                }
                if(Last.Next != null)
                {
                  hold =  Last = Last.Next;
                   
                }

            }

            if (!found)
            {
                throw new NullReferenceException("Node is not a member of the sequence");
            }

            --Count;
        }
        public void AddAfter(Node node, int value)
        {
            if(node == null)
            {
                throw new NullReferenceException("Node cannot be null");
            }
            var hold = Head;

            var found = false; 

            while(hold != null)
            {
                Last = hold;
                hold = Last.Next;

                if(Last == node)
                {
                    found = true;

                    node.Next = new Node(value)
                    {
                        Next = Last.Next
                    };

                    Last = node.Next;
                    hold = Last.Next; 
                  
                }
                if(hold != null)
                {
                    Last = Last.Next;
                }
                
            }

            if (!found)
            {
                throw new NullReferenceException("Node is not part of this sequence");
            }
            Count++;
        }

        public void AddBefore(Node node, int value)
        {
            if(node is null)
            {
                throw new NullReferenceException("Node cannot be null");
            }


            if(Head == node)
            {
                AddFirst(value);
                return;
            }

             Last = Head;

            var found = false;

            while(Last.Next != null)
            {
                if(Last.Next == node)
                {
                    Last.Next = new Node(value)
                    {
                        Next = node
                    };

                    found = true;
                    Last = node;
                    continue;
                }

                Last = Last.Next;
            }

            if (!found)
            {
                throw new NullReferenceException("Node is not part of the sequence");
            }

            Count++;
        }

      
        //finds the node with the particular value in the sequence
        public Node FindValue(int value)
        {
            var hold = Head;

            while (hold != null)
            {
                if (hold.Value == value)
                    return hold;
                hold = hold.Next;
            }

            return null;
        }
        //reference to the last element
        public Node Last { get; private set; }

        //holds the count of the values in the sequence
        public int Count { get; private set; }

        
    }


}
