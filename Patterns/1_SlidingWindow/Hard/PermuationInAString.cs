using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    /// QUESTION: Permutation in a String (hard)
    /// Given a string and a pattern, find out if the string contains any permutation of the pattern.
    //Permutation is defined as the re-arranging of the characters of the string. For example, “abc” has the following six permutations:

    //abc
    //acb
    //bac
    //bca
    //cab
    //cba
    /// If a string has ‘n’ distinct characters, it will have n!n! permutations.
    /// Input: String="oidbcaf", Pattern="abc"
    /// Output: true
    /// Explanation: The string contains "bca" which is a permutation of the given pattern.
    /// 
    /// Input: String="odicf", Pattern="dc"
    //  Output: false
    //  Explanation: No permutation of the pattern is present in the given string as a substring.


    //  Input: String= "bcdxabcdy", Pattern= "bcdyabcdx"
    //  Output: true
    //  Explanation: Both the string and the pattern are a permutation of each other.


    //  Input: String= "aaacb", Pattern= "abc"
    //  Output: true
    //  Explanation: The string contains "acb" which is a permutation of the given pattern.

    /// We use the length of the pattern as k or window size 
    /// </summary>
    public class PermuationInAString
    {
        public static bool HasPermutation(string str, string pattern)
        {
            if(pattern.Length > str.Length)
            {
                return false; 
            }

            int start = 0;

            string temp = "";
            string tempPattern = pattern; 


            for(int end = 0; end < str.Length; end++)
            {
                temp += str[end];
  

                if(temp.Length == pattern.Length)
                {
                    while(tempPattern.Length > 0)
                    {
                        if (tempPattern.Contains(temp[start]))
                        {
                            tempPattern = tempPattern.Remove(tempPattern.IndexOf(temp[start]),1);
                            start++;
                        }
                        else
                        {
                            tempPattern = pattern;
                            temp = temp.Remove(0,1);
                            start = 0; 
                            break;
                        }
                        
                    }

                    if(tempPattern.Length == 0)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
    
        public static bool HasPermutation2(string str, string pattern)
        {
            int windowStart = 0, matched = 0;
            Dictionary<char, int> charFrequencyMap = new Dictionary<char, int>();
            foreach (char chr in pattern)
            {
                if (!charFrequencyMap.TryAdd(chr, 1))
                {
                    charFrequencyMap[chr]++;
                }
            }

            // our goal is to match all the characters from the 'charFrequencyMap' with the current window
            // try to extend the range [windowStart, windowEnd]
            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                char rightChar = str[windowEnd];
                if (charFrequencyMap.ContainsKey(rightChar))
                {
                    // decrement the frequency of the matched character
                    charFrequencyMap[rightChar]--; 

                    if (charFrequencyMap[rightChar] == 0) // character is completely matched
                        matched++;
                }

                if (matched == charFrequencyMap.Count)
                    return true;

                if (windowEnd >= pattern.Length - 1)
                { // shrink the window by one character
                    char leftChar = str[windowStart++];
                    if (charFrequencyMap.ContainsKey(leftChar))
                    {
                        if (charFrequencyMap[leftChar] == 0)
                            matched--; // before putting the character back, decrement the matched count
                                       // put the character back for matching
                        charFrequencyMap[leftChar]++;
                    }
                }
            }

            return false;
        }
    }
}
