using System;

namespace DataStructures
{
    /// <summary>
    /// Implementation of a Singly LinkedList
    /// </summary>
    /// 

    public class SSingleLinkedList
    {
        public LinkedListNode First { get; private set; }
        public LinkedListNode Last { get; private set; }


        //holds the count of the values in the sequence
        public int Count { get; private set; }
       

    }

    public class SingleLinkedList
    {
        public LinkedListNode First { get; private set; }
        public LinkedListNode Last { get; private set; }

        //holds the count of the values in the sequence
        public int Count { get; private set; }

        
        public void AddFirst(int item)
        {
            LinkedListNode node = new LinkedListNode(item); 
            if(IsEmpty())
            {
                First = Last = node; 
            }
            else
            {
                node.Next = First;
                First = node;
            }
            Count++; 

        }

        public void AddLast(int item)
        {
            var node = new LinkedListNode(item);
            if (IsEmpty())
            {
                First = Last = node;
            }
            else
            {
                Last.Next = node;
                Last = node; 
                
            }
            Count++;
        }

        public void RemoveFirst()
        {
            if(IsEmpty())
            {
                return; 
            }

            if(First == Last)
            {
                First = Last = null; 
            }
            else
            {
                var hold = First.Next;
                First.Next = null;
                First = hold;
            }
    

            Count--; 
        }

        public void RemoveLast()
        {
            if(IsEmpty())
            {
                return; 
            }

            if(Last == First)
            {
                Last = First = null; 
            }else
            {
                var previous = GetPreviousNode(Last);
                if(previous == null)
                {
                    return; 
                }
                Last = previous;
                Last.Next = null;
               
            }

            Count--; 
        }

        public void AddBefore(LinkedListNode node, int item)
        {
            if(First == node)
            {
                AddFirst(item);

            }
            else
            {
                var previous = GetPreviousNode(node);

                if (previous == null)
                {
                    return;
                }
                var NewNode = new LinkedListNode(item)
                {
                    Next = previous.Next
                };
                previous.Next = NewNode;
            }
           

            Count++; 
        }

        public void AddAfter(LinkedListNode node, int item)
        {
            if(First == node)
            {
                AddLast(item);
            }
            else
            {
                var previous = GetPreviousNode(node); 

                if(previous == null)
                { return; 
                }

  

                var newNode = new LinkedListNode(item)
                {
                    Next = node.Next 
                };

                node.Next = newNode; 

            }

            Count++; 
   

        }
        public LinkedListNode FindValue(int value)
        {
            var hold = First;

            while (hold != null)
            {
                if (hold.Value == value)
                    return hold;
                hold = hold.Next;
            }

            return null;
        }
        public bool Contains(int value)
        {
            return IndexOf(value) != -1;
        }

        public int IndexOf(int value)
        {
            int index = 0; 
            var hold = First; 
            while (hold!= null)
            {
                if (hold.Value == value)
                {
                    return index;
                }
                hold = hold.Next;
                index++; 
            }
            return -1; 
        }

        public int[] ToArray()
        {
            var array = new int[Count];
            int index = 0;
            var hold = First; 

            while(hold != null)
            {
                array[index++] = hold.Value;

                hold = hold.Next; 
            }

            return array;
        }

        public void RemoveLinkedListNode(LinkedListNode LinkedListNode)
        {
            if (LinkedListNode is null)
            {
                throw new NullReferenceException("LinkedListNode cannot be null");
            }
            if (First is null)
            {
                throw new NullReferenceException("Cannot remove LinkedListNode of an empty list");
            }

            var hold = First;
            if (hold == LinkedListNode)
            {
                RemoveFirst();
                return;
            }
            var found = false;
            while (hold.Next != null)
            {
                Last = hold;

                if (hold.Next == LinkedListNode)
                {
                    var next = LinkedListNode.Next;
                    Last.Next = next;

                    found = true;
                }
                if (Last.Next != null)
                {
                    hold = Last = Last.Next;

                }

            }

            if (!found)
            {
                throw new NullReferenceException("LinkedListNode is not a member of the sequence");
            }

            --Count;
        }

        public void Reverse()
        {
            if(IsEmpty())
            {
                return; 
            }

            SingleLinkedList newList = new();
            var hold = First; 

            while(hold !=null)
            {
                newList.AddFirst(hold.Value);
                hold = hold.Next; 
            }
            First = newList.First;
            Last = newList.Last;
        }
        public void PrintAll()
        {
            var hold = First;
            int i = 0;
            while (hold != null)
            {
                Console.WriteLine($"value {++i} is {hold.Value}");
                hold = hold.Next;
            }
        }

        private LinkedListNode GetPreviousNode(LinkedListNode node)
        {
            var current = First; 
            while(current !=null)
            {
                if(current.Next == node)
                {
                    return current; 
                }
                current = current.Next; 
            }

            return null; 
        }

        public int this[int i]
        {
            get { return i; }
            set {  i = value; }
        }
        private bool IsEmpty()
        {
            return First == null; 
        }
    }

}
