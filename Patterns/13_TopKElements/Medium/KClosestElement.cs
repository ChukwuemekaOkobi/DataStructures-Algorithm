using System;
using System.Collections.Generic;

namespace Patterns._13_TopKElements
{
    /// <summary>
    /// Given a sorted number array and two integers ‘K’ and ‘X’, find ‘K’ closest numbers to ‘X’ in the array. 
    /// Return the numbers in the sorted order. ‘X’ is not necessarily present in the array.

    //    Example 1:

    //Input: [5, 6, 7, 8, 9], K = 3, X = 7
    //Output: [6, 7, 8]
    //    Example 2:

    //Input: [2, 4, 5, 6, 9], K = 3, X = 6
    //Output: [4, 5, 6]
    //    Example 3:

    //Input: [2, 4, 5, 6, 9], K = 3, X = 10
    //Output: [5, 6, 9]
    /// </summary>
    public class KClosestElement
    {
        //two queues 
        public static List<int> Closest(int[] array, int k, int X)
        {
            var list = new List<int>();

            PriorityQueue<int, int> minQueue = new PriorityQueue<int, int>();
            PriorityQueue<int, int> maxQueue = new PriorityQueue<int, int>(new MyComparer()); 

            //O(NlogN)
            for(int i = 0; i<array.Length; i++)
            {
                if(array[i] < X)
                {
                    maxQueue.Enqueue(array[i], array[i]);
                }
                else
                {
                    minQueue.Enqueue(array[i], array[i]);
                }
            }

            //O(KlogN)
            while(!maxQueue.IsEmpty() || !minQueue.IsEmpty())
            {
                int Max = int.MaxValue, min = int.MaxValue; 
                if (!maxQueue.IsEmpty())
                {
                    Max = maxQueue.Peek();
                }
                if (!minQueue.IsEmpty())
                {
                    min = minQueue.Peek(); 
                }

                if(Math.Abs(Max-X) < Math.Abs(min - X))
                {
                    list.Add(maxQueue.Dequeue());
                }
                else
                {
                    list.Add(minQueue.Dequeue());
                }

                if(list.Count == k)
                {
                    break;
                }
            }

            //KLogK
            list.Sort();
            
            return list;
        }
    
        public static List<int> ClosestBinarySearch(int[] arr, int K, int X)
        {

            var list = new List<int>();
            //LogN
            int index = BinarySearch(arr, X);

            int low = index - K, high = index + K;
            low = Math.Max(low, 0); // 'low' should not be less than zero
            high = Math.Min(high, arr.Length - 1); // 'high' should not be greater the size of the array

            PriorityQueue<Entry, int> minHeap = new();
            // add all candidate elements to the min heap, sorted by their absolute difference from 'X'
            //KlogK
            for (int i = low; i <= high; i++)
            {
                var entry = new Entry(Math.Abs(arr[i]-X), i);

                minHeap.Enqueue(entry, entry.key);
            }
                

            // we need the top 'K' elements having smallest difference from 'X'

            //klogK
            for (int i = 0; i < K; i++)
               list.Add(arr[minHeap.Dequeue().value]);

            //KlogK
            list.Sort();

            return list;
        }

        public static List<int> ClosestTwoPoints(int[] arr, int K, int X)
        {
            List<int> result = new ();
            int index = BinarySearch(arr, X);
            int leftPointer = index;
            int rightPointer = index + 1;
            for (int i = 0; i < K; i++)
            {
                if (leftPointer >= 0 && rightPointer < arr.Length)
                {
                    int diff1 = Math.Abs(X - arr[leftPointer]);
                    int diff2 = Math.Abs(X - arr[rightPointer]);
                    if (diff1 <= diff2)
                        result.Insert(0, arr[leftPointer--]); // append in the beginning
                    else
                        result.Add(arr[rightPointer++]); // append at the end
                }
                else if (leftPointer >= 0)
                {
                    result.Insert(0, arr[leftPointer--]);
                }
                else if (rightPointer < arr.Length)
                {
                    result.Add(arr[rightPointer++]);
                }
            }
            return result;
        }
        private static int BinarySearch(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == target)
                    return mid;
                if (arr[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            if (low > 0)
            {
                return low - 1;
            }
            return low;
        }

        class Entry
        {
            public int key;
            public int value;

            public Entry(int key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}
