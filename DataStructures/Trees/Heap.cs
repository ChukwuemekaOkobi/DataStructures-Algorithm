using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class Heap
    {

        private int[] Items;

        public int Count { get; set; }
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

            var index = Count; 
            Items[index] = value;

            BubbleUp(index);

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

        private int GetLargeChildIndex(int index)
        {
            if (!HasLeftChild(index))
            {
                return index; 
            }

            if (!HasRightChild(index))
            {
                return getLeftChildIndex(index);
            }
             return   Items[getLeftChildIndex(index)] > Items[getRightChildIndex(index)]
                    ? getLeftChildIndex(index) : getRightChildIndex(index);

        }
        private bool HasLeftChild(int index)
        {
            return getLeftChildIndex(index) <= Count;
        }

        private bool HasRightChild(int index)
        {
            return getRightChildIndex(index) <= Count; 
        }
        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index)){
                return true;
            }
            if (!HasRightChild(index))
            {
                return Items[index] >= Items[getLeftChildIndex(index)];
            }
            return Items[index] >= Items[getLeftChildIndex(index)] &&
                Items[index] >= Items[getRightChildIndex(index)];
        }
        private int getLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int getRightChildIndex(int index)
        {
            return index * 2 + 1; 
        }

        private void BubbleUp(int index)
        {
            while(index > 0 && Items[index] > Items[getParentIndex(index)])
            {
                Swap(index, getParentIndex(index));

                index = getParentIndex(index); 
            }

        }
        private int getParentIndex (int index)
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
