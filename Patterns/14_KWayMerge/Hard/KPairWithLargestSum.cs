using System.Collections.Generic;

namespace Patterns._14_KWayMerge
{
    /// <summary>
    /// Given two sorted arrays in descending order, find ‘K’ pairs with the largest sum where each pair consists of numbers from both the arrays.

    //    Example 1:

    //Input: L1=[9, 8, 2], L2=[6, 3, 1], K=3
    //Output: [9, 3], [9, 6], [8, 6]
    //    Explanation: These 3 pairs have the largest sum.No other pair has a sum larger than any of these.
    //   Example 2:

    //Input: L1=[5, 2, 1], L2=[2, -1], K=3
    //Output: [5, 2], [5, -1], [2, 2]
    /// </summary>
    public class KPairWithLargestSum
    {
        public static List<int[]> FindKLargestPairs(int[] nums1, int[] nums2, int k)
        {
            PriorityQueue<int[], int> minHeap = new PriorityQueue<int[], int>(); 


            for (int i = 0; i < nums1.Length && i < k; i++)
            {
                for (int j = 0; j < nums2.Length && j < k; j++)
                {
                    if (minHeap.Count < k)
                    {
                        minHeap.Enqueue(new int[] { nums1[i], nums2[j] }, nums1[i]+nums2[j]);
                    }
                    else
                    {
                        // if the sum of the two numbers from the two arrays is smaller than the smallest (top) element of
                        // the heap, we can 'break' here. Since the arrays are sorted in the descending order, we'll not be
                        // able to find a pair with a higher sum moving forward.
                        if (nums1[i] + nums2[j] < minHeap.Peek()[0] + minHeap.Peek()[1])
                        {
                            break;
                        }
                        else
                        { // else: we have a pair with a larger sum, remove top and insert this pair in the heap
                            minHeap.Dequeue();
                            minHeap.Enqueue(new int[] { nums1[i], nums2[j] }, nums2[j]+nums1[i]);
                        }
                    }
                }
            }
            var newList = new List<int[]>();
            while (!minHeap.IsEmpty())
            {
                newList.Add(minHeap.Dequeue());
            }

            return newList; 
        }
    }
}
