using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queues
{
    /// <summary>
    /// First in First Out Datastructure 
    /// This uses a circular array and expands when queue is full 
    /// The begining and end of thw queue is track by pointer to the index
    /// </summary>
    public class ArrayQueue
    {
        private int[] Items; 

        public int Count { get; private set; }

        private int firstPointer = 0;

        private int lastPointer = -1; 
        public ArrayQueue(int length)
        {
            Items = new int[length];
        }

        public void Enqueue(int item)
        {
            if (IsFull())
            {
                //Expand the array
                //copy values in the right order
                int[] newItems = new int[Count * 2];

                for (int i = 0; i < Count; i++)
                {
                    newItems[i] = Items[firstPointer++];

                    if (firstPointer == Count)
                    {
                        firstPointer = 0;
                    }
                }

                Items = newItems;
                firstPointer = 0;
                lastPointer = Count - 1;
            }

            //reset lastPointer to the beginning
            if(lastPointer == Items.Length-1 && Count < Items.Length)
            {
                lastPointer = -1; 
            }

            Items[++lastPointer] = item;
            Count++;

        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is Empty()");
            }

            var item = Items[firstPointer];
            Items[firstPointer++] = 0;
            Count--;

           

            //reset firstPointer to the begineer
            if(firstPointer == Items.Length && Count < Items.Length)
            {
                firstPointer = 0; 
            }
            return item; 
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is Empty()");
            }

            return Items[firstPointer]; 
        }

        public void Reverse()
        {

            //Copy Values in Reverses
            //reset the first and last pointers
            int[] newItems = new int[Items.Length];

            for (int i = 0; i < Count; i++)
            {
                newItems[i] = Items[lastPointer--];

                if(lastPointer == -1)
                {
                    lastPointer = Items.Length - 1;
                }
            }
            Items = newItems;
            firstPointer = 0;
            lastPointer = Count - 1; 

        }

        private bool IsEmpty()
        {
            return Count == 0; 
        }

        private bool IsFull()
        {
            return Items.Length == Count;
        }

        public override string ToString()
        {
            StringBuilder builder = new();

            builder.Append('[');

            for (var i = 0; i < Items.Length; i++)
            {
                builder.Append(Items[i]);
                //if (i != Count - 1)
                    builder.Append(',');
            }

            builder.Append(']');

            return builder.ToString();
        }
    }

    public class PriorityQueue
    {

    }
}
