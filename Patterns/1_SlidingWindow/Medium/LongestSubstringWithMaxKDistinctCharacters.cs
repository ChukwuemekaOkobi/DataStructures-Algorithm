using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    /// Given a string, find the length of the longest substring in it with no more than K distinct characters.
    /// Input: String="araaci", K=2
    /// Output: 4
    /// Explanation: The longest substring with no more than '2' distinct characters is "araa".
    /// 
    /// Input: String="araaci", K=1
    /// Output: 2
    /// Explanation: The longest substring with no more than '1' distinct characters is "aa".
    /// 
    /// Input: String="cbbebi", K=3
    /// Output: 5
    /// Explanation: The longest substrings with no more than '3' distinct characters are "cbbeb" & "bbebi".

    /// Input: String="cbbebi", K=10
    /// Output: 6
    /// Explanation: The longest substring with no more than '10' distinct characters is "cbbebi".
    /// </summary>
    public class LongestSubstringWithMaxKDistinctCharacters
    {
        public static int Length(string str, int k)
        {
            int length = int.MinValue;

            int start = 0;

            var dict = new Dictionary<char,int>(); 

            for(int i = 0; i< str.Length; i++)
            {

                if (!dict.TryAdd(str[i], 1))
                {
                    dict[str[i]] += 1;
                }

                while (dict.Count > k)
                {
                    dict[str[start]]--; 

                    if(dict[str[start]] == 0)
                    {
                        dict.Remove(str[start]);
                    }

                    start++;

                }
                length = Math.Max(length, i - start + 1);

            }
            return length; 
        }

    
    }
}
