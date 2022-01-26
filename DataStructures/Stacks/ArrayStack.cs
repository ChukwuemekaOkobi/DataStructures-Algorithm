using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stacks
{

    /// <summary>
    /// Implementation of Stack , LIFO Data Structure using and Array
    /// </summary>
    public class ArrayStack
    {
        int[] Items;

        public int Count { get; private set; }
        public ArrayStack()
        {
            Items = new int[10];
            Count = 0;
        }

        public void Push(int item)
        {
            if(Count == Items.Length)
            {
                //create a new Array and copy values 

                int[] newArray = new int[Count * 2];

                Items.CopyTo(newArray, 0);

                Items = newArray;
            }
            Items[Count++] = item;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new  Exception("Stack is Empty");
                
            }

           return Items[--Count];
    
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is Empty");

            }

            return Items[Count-1];
        }

        public bool IsEmpty()
        {
            return Count == 0; 
        }

       


        public override string ToString()
        {
            StringBuilder builder = new();

            builder.Append('[');

            for (var i = 0; i < Count; i++)
            {
                builder.Append(Items[i]);
                if (i != Items.Length - 1)
                    builder.Append(',');
            }

            builder.Append(']');

            return builder.ToString();
        }

    }
}
