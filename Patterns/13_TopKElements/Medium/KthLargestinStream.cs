using System.Collections.Generic;

namespace Patterns._13_TopKElements
{
    /// <summary>
    /// find Kth largest number in a stream
    /// </summary>
    public class KthLargestinStream
    {
        private readonly int K;
        readonly PriorityQueue<int, int> queue = new(); 
     
        public KthLargestinStream(int[] nums, int k,bool nk)
        {
            K = k;
            // add the numbers in the min heap
            for (int i = 0; i < nums.Length; i++)
                Add(nums[i]);
        }

        public int Add(int num)
        {
            // add the new number in the min heap
            queue.Enqueue(num,num);

            // if heap has more than 'k' numbers, remove one number
            if (queue.Count > K)
                queue.Dequeue();

            // return the 'Kth largest number
            return queue.Peek();
        }

        

    }
}
