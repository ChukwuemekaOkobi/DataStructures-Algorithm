using System;
using System.Text;

namespace DataStructures
{
    /// <summary>
    /// Implementation of a Singly LinkedList
    /// </summary>

    public class SingleLinkedList
    {
        public LinkedListNode First { get; private set; }
        public LinkedListNode Last { get; private set; }


        //holds the count of the values in the sequence
        public int Count { get; private set; }


        public void AddFirst(int item)
        {
            var hold = new LinkedListNode(item);

            if (IsEmpty())
            {
                First = Last = hold;
                Count++;
                return;
            }

            hold.Next = First;

            First = hold;

            Count++;

            return;

        }

        public void AddLast(int item)
        {
            var hold = new LinkedListNode(item);

            if (IsEmpty())
            {
                First = Last = hold;
                Count++;
                return;
            }

            Last.Next = hold;

            Last = hold;
            Count++;

            return;
        }

        public int IndexOf(int item)
        {
            var hold = First;
            int index = 0; 
            while (hold != null)
            {
                if(hold.Value == item)
                {
                    return index;
                }
                index++;
                hold = hold.Next;
            }
            return -1;
        }

       
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                return;
            }
            if(Count == 1)
            {
                First = Last = null;
                Count--;
                return;
            }
            var hold = First.Next;

            First = hold;
            Count--;

        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                return;
            }
            if(Count == 1)
            {
                First = Last = null;
                Count--;
                return;
            }

            var hold = First; 

            while (hold.Next != Last)
            {
                hold = hold.Next;
            }
            Last = hold;
            Last.Next = null;
        }

        public void AddBefore(int index, int item)
        {
            if (index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            var hold = new LinkedListNode(item);

            if (index == 0)
            {
                AddFirst(item);
                return;
            }

            int count = 1;

            var previous = First;
            
            while (count != index)
            {
                previous = previous.Next;
                count++;
            }


            hold.Next = previous.Next;
            previous.Next = hold;
            Count++; 

        }

        public void AddAfter(int index, int item)
        {

            if (index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            var hold = new LinkedListNode(item);

            if(index == Count - 1)
            {
                AddLast(item);
                return;
            }

            int count = 0;
     
            var current = First;

            while (count != index)
            {
                current = current.Next;
                count++;
            }

            hold.Next = current.Next;
            current.Next = hold;
            Count++;
        }

        public void AddBefore(LinkedListNode node, int item)
        {
            if (First == node)
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
            if (First == node)
            {
                AddLast(item);
            }
            else
            {
                var previous = GetPreviousNode(node);

                if (previous == null)
                {
                    return;
                }



                var newNode = new LinkedListNode(item)
                {
                    Next = node.Next
                };

                node.Next = newNode;

            }

            Count++;


        }
        public void RemoveAt(int index)
        {
            if (index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                RemoveFirst();
                return;
            }
            if(index == Count - 1)
            {
                RemoveLast();
                return;
            }
            var previous = First;
            var current = previous.Next;
            int count = 1;

            while (count != index)
            {
                previous = current;
                current = current.Next;
                count++;
            }

            previous.Next = current.Next;
            Count--;

        }

        public void Reverse()
        {
            if (IsEmpty())
            {
                return;
            }
            SingleLinkedList newList = new();
            var hold = First;

            while (hold != null)
            {
                newList.AddFirst(hold.Value);
                hold = hold.Next;
            }
            First = newList.First;
            Last = newList.Last;
        }

        public void ReverseInPlace()
        {
            LinkedListNode previous = null; 

            while (First != null)
            {
                LinkedListNode Next = First.Next;

                First.Next = previous;

                previous = First;

                First = Next; 
            }
            First = previous; 
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

        public int[] ToArray()
        {
            var newArray = new int[Count];

            var hold = First;

            var index = 0;
            while (hold != null)
            {
                newArray[index++] = hold.Value;
                hold = hold.Next;
            }
            return newArray;
        }

        public int this[int i]
        {
            get { return FindValue(i); }
            set
            {
            }
        }


        public bool Contains(int value)
        {
            return IndexOf(value) != -1;
        }

        public void PrintAll()
        {
            var hold = First;
            while (hold != null)
            {
                Console.WriteLine(hold.Value);
                hold = hold.Next;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new();

            builder.Append('[');


            var hold = First;
            while (hold != null)
            {
                builder.Append(hold.Value);
                builder.Append(',');
                hold = hold.Next;
            }
            builder.Append(']');

            return builder.ToString();
        }

        private int FindValue(int index)
        {
            if (index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }


            var hold = First;

            int count = 0;

            while (count != index)
            {
                hold = hold.Next;
                count++;
            }

            return hold.Value;
        }
        private LinkedListNode GetPreviousNode(LinkedListNode node)
        {
            var current = First;
            while (current != null)
            {
                if (current.Next == node)
                {
                    return current;
                }
                current = current.Next;
            }

            return null;
        }


        private bool IsEmpty()
        {
            return First == null;
        }


    }

}
