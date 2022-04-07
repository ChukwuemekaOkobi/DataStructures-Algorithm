using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns._13_TopKElements
{
    /// <summary>
    /// Given an unsorted array of numbers, find the top ‘K’ frequently occurring numbers in it.

    //Example 1:

    //Input: [1, 3, 5, 12, 11, 12, 11], K = 2
    //Output: [12, 11]
    //Explanation: Both '11' and '12' apeared twice.
    //Example 2:

    //Input: [5, 12, 11, 3, 11], K = 2
    //Output: [11, 5] or[11, 12] or [11, 3]
    //Explanation: Only '11' appeared twice, all other numbers appeared once.
    /// </summary>
    public class TopKFrequent
    {
        public static List<int> FindTopKFrequentNumbers(int[] nums, int k)
        {
            List<int> topNumbers = new (k);

            Dictionary<int, int> dict = new(); 

            foreach(var num in nums)
            {
                if (!dict.TryAdd(num, 1))
                {
                    dict[num]++;
                }
            }

            PriorityQueue<int, int> queue = new PriorityQueue<int, int>(); 

            foreach(var item in dict)
            {
                queue.Enqueue(item.Key, item.Value); 

                if(queue.Count> k)
                {
                    queue.Dequeue();
                }
   
            }

            while(queue.Count != 0)
            {
                topNumbers.Add(queue.Dequeue());
            }

            return topNumbers;
        }
    }

}
