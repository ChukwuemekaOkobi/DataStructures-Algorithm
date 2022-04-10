using System.Collections.Generic;

namespace ProblemsAndSolutions.Google
{
    public class MinCostConnectingSticks
    {
        public static int Find (int[] nums)
        {
            PriorityQueue<int, int> queue = new();

            for (int i = 0; i < nums.Length; i++)
            {
                queue.Enqueue(nums[i], nums[i]);
            }

              int cost  = 0;

            while (queue.Count >= 2)
            {
                var temp = queue.Dequeue() + queue.Dequeue(); 

                queue.Enqueue(temp,temp);
                cost += temp;
            }

            return cost;
        }
    }
}
