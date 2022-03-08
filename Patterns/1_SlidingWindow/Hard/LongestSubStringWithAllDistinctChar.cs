using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    /// Given a string, find the length of the longest substring, which has all distinct characters.
    /// Input: String="aabccbb"
    /// Output: 3
    /// Explanation: The longest substring with distinct characters is "abc".
    /// 
    /// Input: String="abbbb"
    /// Output: 2
    /// Explanation: The longest substring with distinct characters is "ab".
    /// s 
    /// Input: String="abccde"
    /// Output: 3
    /// Explanation: Longest substrings with distinct characters are "abc" & "cde".
    /// </summary>
    public class LongestSubStringWithAllDistinctChar
    {
        public static int LengthNoRepeating(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0; 
            }
            int length = 0;
            HashSet<char> set = new HashSet<char>(); 

            for(int end = 0; end < str.Length; end++)
            {
                if (!set.Contains(str[end]))
                {
                    set.Add(str[end]);
                }
                else
                {
                    length = Math.Max(set.Count, length);

                    set = new HashSet<char>
                    {
                        str[end]
                    };

                }
                       
            }

            return length;
        }

        public static int Length2(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }
            int length = 0;
            int start = 0;

            HashSet<char> set = new HashSet<char>();

            for (int end = 0; end < str.Length; end++)
            {
                if (!set.Contains(str[end]))
                {
                    set.Add(str[end]);
                }
                else
                {
                    length = Math.Max(set.Count, length);

                    while (set.Count > 1)
                    {
                        set.Remove(str[start]);
                        start++;
                    }
                }

            }

            return length;
        }
    }
}
