using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    /// QUESTION: Longest Substring with Same Letters after Replacement (hard)
    /// Given a string with lowercase letters only, if you are allowed to replace no more than k letters with any letter, 
    /// find the length of the longest substring having the same letters after replacement.
    /*
     *  Input: String="aabccbb", k=2
        Output: 5
        Explanation: Replace the two 'c' with 'b' to have the longest repeating substring "bbbbb".

        Input: String="abbcb", k=1
        Output: 4
        Explanation: Replace the 'c' with 'b' to have the longest repeating substring "bbbb".

        Input: String="abccde", k=1
        Output: 3
        Explanation: Replace the 'b' or 'd' with 'c' to have the longest repeating substring "ccc".
    */
   /// </summary>
    public class SubstringWIthTheSameCharAfterReplacement
    {
        public static int Length(string str, int k)
        {
            int repeated = 0;

            int start = 0;

            int max = 0;


            Dictionary<char, int> dict = new Dictionary<char, int>(); 

          
            for(int end = 0; end < str.Length; end++)
            {
                if (!dict.TryAdd(str[end], 1))
                {
                    dict[str[end]]++;
                }

                repeated = Math.Max(repeated, dict[str[end]]);

                //check if the number of letter left does not exceed k
                if((end-start +1- repeated) > k)
                {
                    dict[str[start]]--;
                    start++;
                }

                max = Math.Max(max, end - start + 1);
            }


            return max; 
        }
    }
}
