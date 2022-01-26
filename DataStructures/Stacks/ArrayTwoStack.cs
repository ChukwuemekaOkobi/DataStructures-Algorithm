using System;

using System.Text;

namespace DataStructures.Stacks
{
    public class ArrayTwoStack
    {
        readonly int[] Items;


        public int Count1 { get; private set; }
        public int Count2 { get; private set; }
        public ArrayTwoStack()
        {
            Items = new int[10];
            Count1 = 0;
            Count2 = 0;
        }

        public void Push1(int item)
        {
            if (IsArrayFull())
            {
                throw new Exception("Stack is Full");
            }

            Items[Count1++] = item;

        }
        public void Push2(int item)
        {
            if (IsArrayFull())
            {
                throw new Exception("Stack is Full");
            }

            //index = Items.Length - (++Count2) = ^(++Count2)

            //fill in from the last index 

            Items[^(++Count2)] = item;
        }
        
        public int Pop1()
        {
            if (IsEmpty1())
            {
                throw new Exception("Stack 1 is Empty");
            }

            var item = Items[Count1-1];

            Items[--Count1] = 0;

            return item;
        }
        public int Pop2()
        {
            if (IsEmpty2())
            {
                throw new Exception("Stack 2 is Empty");
            }

            var item = Items[^Count2];

            Items[^Count2--] = 0;
           
            return item;
        }
        public int Peek1()
        {
            if (IsEmpty1())
            {
                throw new Exception("Stack 1 is Empty");
            }

            return Items[Count1 - 1];
        }

        public int Peek2()
        {
            if (IsEmpty2())
            {
                throw new Exception("Stack 2 is Empty");
            }

            return Items[^Count2];
        }

        public bool IsEmpty1()
        {
            return Count1 == 0;
        }

        public bool IsEmpty2()
        {
            return Count2 == 0;
        }


        // Can also Dynamically Expand the length of the Array 
        // and Copy the Values into a new array
        private bool IsArrayFull()
        {
            return Count2 + Count1 == Items.Length;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append('[');

            for(var i = 0; i<Items.Length; i++)
            {
                builder.Append(Items[i]);
                if(i != Items.Length -1)
                    builder.Append(',');
            }

            builder.Append(']');

            return builder.ToString();
        }

    }
}
