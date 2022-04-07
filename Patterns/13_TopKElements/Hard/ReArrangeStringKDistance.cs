using System.Collections.Generic;
using System.Text;

namespace Patterns._13_TopKElements
{
    /// <summary>
    /// rearrange string atleast k distance apart
    /// </summary>
    public class ReArrangeStringKDistance
    {
        public static string Rearrange(string str, int k)
        {
            Dictionary<char, int> dict = new();

            foreach (char ch in str)
            {
                if (!dict.TryAdd(ch, 1))
                {
                    dict[ch]++;
                }
            }

            PriorityQueue<Pair, int> queue = new(new MyComparer());

            foreach (var item in dict)
            {
                queue.Enqueue(new Pair(item.Key, item.Value), item.Value);
            }



            StringBuilder resultString = new StringBuilder(str.Length);
            Queue<Pair> distqueue = new ();

            while (!queue.IsEmpty())
            {
                Pair currentEntry = queue.Dequeue();
               
                // append the current character to the result string and decrement its count
                resultString.Append(currentEntry.Key);
                currentEntry.Value--;
                distqueue.Enqueue(currentEntry);
                if (queue.Count == k)
                {
                    var entry = distqueue.Dequeue();
                    if (entry.Value > 0)
                        queue.Enqueue(entry,entry.Value);
                }

            }

            // if we were successful in appending all the characters to the result string, return it
            return resultString.Length == str.Length ? resultString.ToString() : "";

        }
    }
}
