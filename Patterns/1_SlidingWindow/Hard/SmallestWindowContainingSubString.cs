using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    /// QUESTION: Smallest Window containing Substring (hard)
    /// 
    /* Given a string and a pattern, find the smallest substring in the given string which has all the character occurrences of the given pattern.

        Example 1:

        Input: String="aabdec", Pattern="abc"
        Output: "abdec"
        Explanation: The smallest substring having all characters of the pattern is "abdec"
        Example 2:

        Input: String="aabdec", Pattern="abac"
        Output: "aabdec"
        Explanation: The smallest substring having all character occurrences of the pattern is "aabdec"
        Example 3:

        Input: String="abdbca", Pattern="abc"
        Output: "bca"
        Explanation: The smallest substring having all characters of the pattern is "bca".
        Example 4:

        Input: String="adcad", Pattern="abc"
        Output: ""
        Explanation: No substring in the given string has all characters of the pattern.
    */
    /// </summary>
    public class SmallestWindowContainingSubString
    {
        public static string SubString(string str, string pattern)
        {

    
            var dict = new Dictionary<char, int>();

            foreach (var ch in pattern)
            {
                if (!dict.TryAdd(ch, 1))
                {
                    dict[ch]++;
                }
            }

            int start = 0;
            int match = 0;
            int minLength = str.Length + 1;
            int subStrStart = 0; 

         
            for (int end = 0; end < str.Length; end++)
            {
                if (dict.ContainsKey(str[end]))
                {
                    dict[str[end]]--; 
                    if(dict[str[end]] >= 0)
                    {
                        match++; 
                    }
                }

                while (match == pattern.Length)
                {
                    if (minLength > end - start + 1)
                    {
                        minLength = end - start + 1;
                        subStrStart = start;
                    }

                    char leftChar = str[start++];
                    if (dict.ContainsKey(leftChar))
                    {
                        // note that we could have redundant matching characters, therefore we'll decrement the
                        // matched count only when a useful occurrence of a matched character is going out of the window
                        if (dict[leftChar] == 0)
                            match--;
                        dict[leftChar]++;
                    }
                }
            }

            return minLength > str.Length ? "" : str.Substring(subStrStart, subStrStart + minLength-1);

        }
    }
}
