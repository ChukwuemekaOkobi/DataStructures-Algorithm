using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._9_TwoHeaps
{
    /// <summary>
    /// Given an array of numbers and a number ‘k’, find the median of all the ‘k’ sized sub-arrays (or windows) of the array.

    //Example 1:

    //Input: nums=[1, 2, -1, 3, 5], k = 2
    //Output: [1.5, 0.5, 1.0, 4.0]
    //Explanation: Lets consider all windows of size ‘2’:

    //[ 1, 2 1,2, -1, 3, 5] -> median is 1.5
    //[1, 2,2, -1 1, 3, 5] -> median is 0.5
    //[1, 2, -1, 3,1,3, 5] -> median is 1.0
    //[1, 2, -1, 3, 5 3,5] -> median is 4.0
    //Example 2:

    //Input: nums=[1, 2, -1, 3, 5], k = 3
    //Output: [1.0, 2.0, 3.0]

    /// </summary>
    public class SlidingWindowMedian
    {
        readonly PriorityQueue<int, int> maxHeap = new(new MaxComparer());
        readonly PriorityQueue<int, int> minHeap = new();

        public double[] FindSlidingWindowMedian(int[] nums, int k)
        {
            double[] result = new double[nums.Length - k + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                if (maxHeap.Count == 0 || maxHeap.Count >= nums[i])
                {
                    maxHeap.Enqueue(nums[i], nums[i]);
                }
                else
                {
                    minHeap.Enqueue(nums[i], nums[i]);
                }
                RebalanceHeaps();

                if (i - k + 1 >= 0)
                { // if we have at least 'k' elements in the sliding window
                  // add the median to the the result array
                    if (maxHeap.Count == minHeap.Count)
                    {
                        // we have even number of elements, take the average of middle two elements
                        result[i - k + 1] = maxHeap.Peek() / 2.0 + minHeap.Peek() / 2.0;
                    }
                    else
                    { // because max-heap will have one more element than the min-heap
                        result[i - k + 1] = maxHeap.Peek();
                    }

                    // remove the element going out of the sliding window
                    int elementToBeRemoved = nums[i - k + 1];
                    if (elementToBeRemoved <= maxHeap.Peek())
                    {
                        maxHeap.Remove(elementToBeRemoved);
                    }
                    else
                    {
                        minHeap.Remove(elementToBeRemoved);
                    }
                    RebalanceHeaps();
                }
            }
            return result;
        }

        private void RebalanceHeaps()
        {
            // either both the heaps will have equal number of elements or max-heap will have 
            // one more element than the min-heap
            if (maxHeap.Count > minHeap.Count + 1)
            {
                var item = maxHeap.Dequeue();
                minHeap.Enqueue(item, item);
            }

            else if (maxHeap.Count < minHeap.Count)
            {
                var item = minHeap.Dequeue();
                maxHeap.Enqueue(item, item);
            }

        }

    }
}