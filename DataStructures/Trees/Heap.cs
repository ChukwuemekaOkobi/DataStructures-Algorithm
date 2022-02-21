using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class Heap
    {

        private readonly int[] Items;

        public int Count { get; private set; }
        public Heap()
        {
            Items = new int[10];
            Count = 0;
        }


        public void Insert(int value)
        {
            if(Count == Items.Length)
            {
                return;
            }

            Items[Count] = value;
            
            BubbleUp(Count);

            Count++; 
        }

        public int Remove()
        {
            if(Count == 0)
            {
                return 0; 
            }
            var item = Items[0];
            Items[0] = Items[--Count];

            var index = 0;
            BubbleDown(index);

            return item;

        }

        public bool IsEmpty()
        {
            return Count == 0; 
        }
        
        private void BubbleDown(int index)
        {
            while(index<= Count && !IsValidParent(index))
            {
                var largeChildIndex = GetLargeChildIndex(index);

                Swap(index, largeChildIndex);

                index = largeChildIndex;
            }
        }
        private void BubbleUp(int index)
        {
            while (index > 0 && Items[index] > Items[GetParentIndex(index)])
            {
                Swap(index, GetParentIndex(index));

                index = GetParentIndex(index);
            }

        }
        private int GetLargeChildIndex(int index)
        {
            if (!HasLeftChild(index))
            {
                return index; 
            }

            if (!HasRightChild(index))
            {
                return GetLeftChildIndex(index);
            }
             return   Items[GetLeftChildIndex(index)] > Items[GetRightChildIndex(index)]
                    ? GetLeftChildIndex(index) : GetRightChildIndex(index);

        }
        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) <= Count;
        }

        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) <= Count; 
        }
        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index)){
                return true;
            }
            if (!HasRightChild(index))
            {
                return Items[index] >= Items[GetLeftChildIndex(index)];
            }
            return Items[index] >= Items[GetLeftChildIndex(index)] &&
                Items[index] >= Items[GetRightChildIndex(index)];
        }
       
        private static int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private static int GetRightChildIndex(int index)
        {
            return index * 2 + 2; 
        }

        
        private static int GetParentIndex (int index)
        {
            return (index - 1) / 2;
        }
        private void Swap(int child, int parent)
        {
            int temp = Items[child];
            Items[child] = Items[parent];
            Items[parent] = temp;
        }
   

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append('[');

            for(int i = 0; i< Count; i++)
            {
                builder.Append(Items[i] + ",");
            }

            return builder.Append(']').ToString();
        }
    }
}
