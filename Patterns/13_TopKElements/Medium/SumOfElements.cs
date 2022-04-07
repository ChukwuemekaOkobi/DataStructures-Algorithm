using System.Collections.Generic;

namespace Patterns._13_TopKElements
{
    /// <summary>
    /// Given an array, find the sum of all numbers between the K1’th and K2’th smallest elements of that array.
    //Example 1:
    //Input: [1, 3, 12, 5, 15, 11], and K1 = 3, K2 = 6
    //Output: 23
    //Explanation: The 3rd smallest number is 5 and 6th smallest number 15. The sum of numbers coming
    //between 5 and 15 is 23 (11+12).
    //Example 2:
    //Input: [3, 5, 8, 7], and K1 = 1, K2 = 4
    //Output: 12
    //Explanation: The sum of the numbers between the 1st smallest number(3) and the 4th smallest
    //number(8) is 12 (5+7).
    /// </summary>
    public class SumOfElements
    {
        public static int FindSum(int[] nums, int k1, int k2)
        {
            PriorityQueue<int, int> queue = new(); 

            foreach(var num in nums)
            {
                queue.Enqueue(num, num); 
            }

            int sum = 0;

            for(int i =0; i<k1; i++)
            {
                queue.Dequeue(); 
            }
           
            for(int i = k1+1; i< k2; i++)
            {
                sum += queue.Dequeue();
            }

           

            return sum;
        }

        public static int FindSumMaxHeap(int[] nums, int k1, int k2)
        {
            PriorityQueue<int,int> maxHeap = new PriorityQueue<int, int>(new MyComparer());
            // keep smallest k2 numbers in the max heap
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < k2 - 1)
                {
                    maxHeap.Enqueue(nums[i],nums[i]);
                }
                else if (nums[i] < maxHeap.Peek())
                {
                    maxHeap.Dequeue(); // as we are interested only in the smallest k2 numbers
                    maxHeap.Enqueue(nums[i], nums[i]);
                }
            }

            // get the sum of numbers between k1 and k2 indices
            // these numbers will be at the top of the max heap
            int elementSum = 0;
            for (int i = 0; i < k2 - k1 - 1; i++)
                elementSum += maxHeap.Dequeue();

            return elementSum;
        }
    }

}
