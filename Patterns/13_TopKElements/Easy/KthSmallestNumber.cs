using System.Collections.Generic;

namespace Patterns._13_TopKElements
{
    /// <summary>
    ///   Given an unsorted array of numbers, find Kth smallest number in it.
    //    Please note that it is the Kth smallest number in the sorted order, not the Kth distinct element.
    //    Note: For a detailed discussion about different approaches to solve this problem, take a look at Kth Smallest Number.
    //    Example 1:
    //    Input: [1, 5, 12, 2, 11, 5], K = 3
    //    Output: 5
    //    Explanation: The 3rd smallest number is '5', as the first two smaller numbers are [1, 2].
    //    Example 2:
    //    Input: [1, 5, 12, 2, 11, 5], K = 4
    //    Output: 5
    //    Explanation: The 4th smallest number is '5', as the first three small numbers are [1, 2, 5].
    //    Example 3:
    //    Input: [5, 12, 11, -1, 12], K = 3
    //    Output: 11
    //    Explanation: The 3rd smallest number is '11', as the first two small numbers are [5, -1].
    /// </summary>

    public class KthSmallestNumber
    {
        public static int Find(int[] nums, int k)
        {
            // use max heap
            PriorityQueue<int, int> queue = new(new MyComparer());


            for (int i = 0; i < nums.Length; i++)
            {
                if (queue.Count < k)
                {
                    queue.Enqueue(nums[i], nums[i]);
                }
                else
                {
                    if (queue.Peek() > nums[i])
                    {
                        queue.Dequeue();
                        queue.Enqueue(nums[i], nums[i]);
                    }
                }
            }

            return queue.Peek();
        }
       
    }

    public class MyComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }

}
