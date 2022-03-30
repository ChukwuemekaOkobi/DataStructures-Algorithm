using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._9_TwoHeaps
{

    /// <summary>
    /// Design a class that accepts a stream and outputs the median value
    /// Design a class to calculate the median of a number stream. The class should have the following two methods:

    // insertNum(int num) : stores the number in the class
    // findMedian(): returns the median of all numbers inserted in the class
    // If the count of numbers inserted in the class is even, the median will be the average of the middle two numbers.
    /// </summary>
    public class MedianOfAStream
    {
        
        readonly int[] array = new int[10];
        int count = 0;
        public void InsertNum(int num)
        {
            array[count++] = num;
        }

        //O(N logN) space complete = O(N)
        public double FindMedian()
        {
            if(count == 0)
            {
                return -1; 
            }
            int[] copiedArray = new int[count];

            Array.Copy(array, copiedArray, count);

            Array.Sort(copiedArray);

            int m = count / 2;

            if (count % 2 == 0)
            {
                return (double)(copiedArray[m] + copiedArray[m - 1]) / 2;
            }
            else
            {

                return copiedArray[m];
            }
        }
    }


    /// <summary>
    /// Using Two Heaps
    /// </summary>
    public class MedianOfAStream2
    {
        readonly PriorityQueue<int,int> maxHeap; //containing first half of numbers
        private readonly PriorityQueue<int,int> minHeap; //containing second half of numbers

        public MedianOfAStream2()
        {
            maxHeap = new PriorityQueue<int, int>(new MaxComparer());
            minHeap = new PriorityQueue<int, int>();
        }

        public void InsertNum(int num)
        {
            if (maxHeap.Count == 0 || maxHeap.Peek() >= num)
                maxHeap.Enqueue(num,num);
            else
                minHeap.Enqueue(num,num);

            // either both the heaps will have equal number of elements or max-heap will have one 
            // more element than the min-heap
            if (maxHeap.Count > minHeap.Count + 1)
            {
                var item = maxHeap.Dequeue();
                minHeap.Enqueue(item, item);
            }
            else if (maxHeap.Count < minHeap.Count)
            {
                var item = minHeap.Dequeue();
                maxHeap.Enqueue(item,item);
            }
        }

        public double FindMedian()
        {
            
            if (maxHeap.Count == minHeap.Count)
            {
                // we have even number of elements, take the average of middle two elements
                return maxHeap.Peek() / 2.0 + minHeap.Peek() / 2.0;
            }
            // because max-heap will have one more element than the min-heap
            return maxHeap.Peek();
        }

    }

    public class MaxComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }

}