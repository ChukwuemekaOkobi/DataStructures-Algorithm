using System.Collections.Generic;
using System.Text;

namespace Patterns._13_TopKElements
{
    /// <summary>
    /// Given a string, sort it based on the decreasing frequency of its characters.

    // Example 1:

    //Input: "Programming"
    //Output: "rrggmmPiano"
    //Explanation: 'r', 'g', and 'm' appeared twice, so they need to appear before any other character.
    //Example 2:

    //Input: "abcbab"
    //Output: "bbbaac"
    //Explanation: 'b' appeared three times, 'a' appeared twice, and 'c' appeared only once.
    /// </summary>
    public class FrequencySort
    {
        public static string DecreasingFrequency(string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>(); 

            foreach(var ch in str)
            {
                if (!dict.TryAdd(ch, 1))
                {
                    dict[ch]++;
                }
            }

            PriorityQueue<char, int> queue = new PriorityQueue<char, int>(new MyComparer()); 

            foreach(var item in dict)
            {
                queue.Enqueue(item.Key, item.Value);
            }

            StringBuilder builder = new StringBuilder(); 

            while (!queue.IsEmpty())
            {
                queue.TryDequeue(out char el, out int count);

                while (count > 0)
                {
                    builder.Append(el);
                    count--;
                }
            }

            return builder.ToString();
        }
    }
}
