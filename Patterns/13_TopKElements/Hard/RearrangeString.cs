using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._13_TopKElements
{
    /// <summary>
    /// Given a string, find if its letters can be rearranged in such a way that no two same characters come next to each other.
    //Example 1:

    //Input: "aappp"
    //Output: "papap"
    //Explanation: In "papap", none of the repeating characters come next to each other.
    //Example 2:

    //Input: "Programming"
    //Output: "rgmrgmPiano" or "gmringmrPoa" or "gmrPagimnor", etc.
    //Explanation: None of the repeating characters come next to each other.
    //Example 3:

    //Input: "aapa"
    //Output: ""
    //Explanation: In all arrangements of "aapa", atleast two 'a' will come together e.g., "apaa", "paaa".
    /// </summary>
    public class RearrangeString
    {
        public static string Rearrange(string str)
        {
            Dictionary<char, int> dict = new();

            foreach(char ch in str)
            {
                if (!dict.TryAdd(ch, 1))
                {
                    dict[ch]++;
                }
            }

            PriorityQueue<Pair, int> queue = new(new MyComparer());

            foreach(var item in dict)
            {
                queue.Enqueue(new Pair(item.Key,item.Value), item.Value);
            }

            Pair previousEntry = null;


            StringBuilder resultString = new StringBuilder(str.Length);


            while (!queue.IsEmpty())
            {
                Pair currentEntry = queue.Dequeue();
                // add the previous entry back in the heap if its frequency is greater than zero
                if (previousEntry != null && previousEntry.Value > 0)
                    queue.Enqueue(previousEntry, previousEntry.Value);
     
                // append the current character to the result string and decrement its count
                resultString.Append(currentEntry.Key);
                currentEntry.Value--;

                previousEntry = currentEntry;
            }

            // if we were successful in appending all the characters to the result string, return it
            return resultString.Length == str.Length ? resultString.ToString() : "";

        }

    }

    public class Pair
    {
        public char Key { get; set; }
        public int Value { get; set; }

        public int dist { get; set; }

        public Pair(char key, int value)
        {
            Key = key;
            Value = value;
        }
    }
}
