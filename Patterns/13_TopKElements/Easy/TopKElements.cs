using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._13_TopKElements
{
    /// <summary>
    /// Given an unsorted array of numbers, find the ‘K’ largest numbers in it.

    //Example 1:

    //Input: [3, 1, 5, 12, 2, 11], K = 3
    //Output: [5, 12, 11]
    //Example 2:

    //Input: [5, 12, 11, -1, 12], K = 3
    //Output: [12, 11, 12]
    /// </summary>
    public class TopKElements
    {
        public static List<int> FindLargestNumberBruteForce(int[] nums, int k)
        {
            //sort the array 

            Array.Sort(nums);

            var list = new List<int>();
            int count = 0; 

            for(int i = nums.Length-1; i>=0; i--)
            {
                list.Add(nums[i]);
                count++;
                if(count == k)
                {
                    break;
                }
            }

            return list;
        }

        public static List<int> FindLargestHeap(int[] nums, int k)
        {
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();

            var list = new List<int>();

            for(int i = 0; i < nums.Length; i++)
            { 
                if(queue.Count< k)
                {
                    queue.Enqueue(nums[i], nums[i]);
                }
                else
                {
                    if(queue.Peek() < nums[i])
                    {
                        queue.Dequeue();
                        queue.Enqueue(nums[i],nums[i]);
                    }
                }
            }

            while (!queue.IsEmpty())
            {
                list.Add(queue.Dequeue());
            }


            return list; 

        }
    }

}
