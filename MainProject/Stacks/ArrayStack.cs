using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stacks
{
    public class ArrayStack
    {
        int[] Items;

        public ArrayStack()
        {
            Items = new int[10];
            Count = 0; 
        }
        public int Count{ get; private set; }

        public void Push(int item)
        {
            if(Count == Items.Length)
            {
                int[] newItems = new int[Count * 2];

                for(int i = 0; i<Items.Length; i++)
                {
                    newItems[i] = Items[i];
                }

                Items = newItems;
            }

            Items[Count++] = item; 
        }
        public int Pop()
        {
            if(IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }

            int lastItem = Items[Count-1];

            Items[--Count] = 0; 

            return lastItem; 
             
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }
            return Items[Count - 1]; 
        }

        public bool IsEmpty()
        {
            return Count == 0; 
        }

    }
}
