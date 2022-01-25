using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stacks
{
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

    }


    public class ArrayTwoStack
    {
        int[] Items;


        public int Count1 { get; private set; }
        public int Count2 { get; private set; }
        public ArrayTwoStack()
        {
            Items = new int[10];
            Count1 = 0;
            Count2 = 0;
        }

      
    }
}
