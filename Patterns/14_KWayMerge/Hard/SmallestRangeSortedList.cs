using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._14_KWayMerge
{
    public class SmallestRangeSortedList
    {
        public static int[] FindSmallestRange(List<int[]> lists)
        {
            PriorityQueue<Node, int> minHeap = new PriorityQueue<Node, int>();

            int rangeStart = 0, rangeEnd = int.MaxValue, currentMaxNumber = int.MinValue; 
            // put the 1st element of each array in the min heap
            for (int i = 0; i < lists.Count; i++)
                if (lists[i] != null)
                {
                    minHeap.Enqueue(new Node(0, i),lists[i][0]);
                    currentMaxNumber = Math.Max(currentMaxNumber, lists[i][0]);
                }

            // take the smallest (top) element form the min heap, if it gives us smaller range, update the ranges
            // if the array of the top element has more elements, insert the next element in the heap
            while (minHeap.Count == lists.Count)
            {
                Node node = minHeap.Dequeue();
                if (rangeEnd - rangeStart > currentMaxNumber - lists[node.arrayIndex][node.elementIndex])
                {
                    rangeStart = lists[node.arrayIndex][node.elementIndex];
                    rangeEnd = currentMaxNumber;
                }
                node.elementIndex++;
                if (lists[node.arrayIndex].Length > node.elementIndex)
                {
                    minHeap.Enqueue(node,lists[node.arrayIndex][node.elementIndex]); // insert the next element in the heap
                    currentMaxNumber = Math.Max(currentMaxNumber, lists[node.arrayIndex][node.elementIndex]);
                }
            }
            return new int[] { rangeStart, rangeEnd };
        }
    }
}
