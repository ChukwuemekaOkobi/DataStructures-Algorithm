using System;

namespace DataStructures.Queues
{
    /// <summary>
    /// Implementing Queue with a LinkedList
    /// </summary>
    public class LinkedListQueue
    {
        SingleLinkedList Items; 

        public LinkedListQueue()
        {
            Items = new SingleLinkedList(); 
        }

        public int Count => Items.Count; 

        public void Enqueue(int item)
        {
            Items.AddLast(item);

        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is Empty()");
            }

            var item = Items.First.Value;
            Items.RemoveFirst(); 
            return item;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is Empty()");
            }

            return Items.First.Value;
        }

        public void Reverse()
        {
            Items.Reverse();
        }

        private bool IsEmpty()
        {
            return Count == 0;
        }


        public override string ToString()
        {
            return Items.ToString();
        }
    }
}
