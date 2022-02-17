using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class PriorityQueueWithHeap
    {
        private readonly Heap Heap; 

        public PriorityQueueWithHeap()
        {
            Heap = new Heap();
        }
        public void Enqueue(int item)
        {
            Heap.Insert(item);
        }

        public int Dequeue()
        {
            return Heap.Remove();
        }

        public bool IsEmpty()
        {
            return Heap.IsEmpty();
        }
    }
}
