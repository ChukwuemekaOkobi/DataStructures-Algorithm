using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    /// <summary>
    /// Implementation of a doubley LinkedList
    /// </summary>
    
    public class DoubleLinkedList
    {
        public LinkedListNode First { get; private set; }
        public LinkedListNode Last { get; private set; }

        public int Count { get; private set; }


    }
    public class DDLinkedList
    {
        public LinkedListNode First { get; private set; }
        public LinkedListNode Last { get; private set; }

        //holds the count of the values in the sequence
        public int Count { get; private set; }

        public void AddFirst(int item)
        {
            var node = new LinkedListNode(item);
            if (isEmpty())
            {
                First = Last = node;

            }
            else
            {
                First.Previous = node; 
                node.Next = First;
                First = node;
            }
            Count++;

        }

        public void AddLast(int item)
        {
            var node = new LinkedListNode(item);
            if (isEmpty())
            {
                First = Last = node;
            }
            else
            {
                node.Previous = Last;
                Last.Next = node;
                Last = node;

            }
            Count++;
        }

        public void RemoveFirst()
        {
            if (isEmpty())
            {
                return;
            }

            if (First == Last)
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
            if (isEmpty())
            {
                return;
            }

            if (Last == First)
            {
                Last = First = null;
            }
            else
            {
                var previous = getPreviousNode(Last);
                if (previous == null)
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
            if (First == node)
            {
                AddFirst(item);

            }
            else
            {
                var previous = getPreviousNode(node);

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
                var previous = getPreviousNode(node);

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
            while (hold != null)
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

            while (hold != null)
            {
                array[index++] = hold.Value;

                hold = hold.Next;
            }

            return array;
        }


        private LinkedListNode getPreviousNode(LinkedListNode node)
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

        private bool isEmpty()
        {
            return First == null;
        }
    }
}

