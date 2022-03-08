using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    /// 
    /*Given a string and a pattern, find all anagrams of the pattern in the given string.

    Every anagram is a permutation of a string. As we know, when we are not allowed to repeat characters 
    while finding permutations of a string, we get N!N! permutations (or anagrams) of a string having NN characters.
    For example, here are the six anagrams of the string “abc”:
    abc
    acb
    bac
    bca
    cab
    cba
    Write a function to return a list of starting indices of the anagrams of the pattern in the given string.

    Example 1:

    Input: String="ppqp", Pattern="pq"
    Output: [1, 2]
    Explanation: The two anagrams of the pattern in the given string are "pq" and "qp".
    Example 2:

    Input: String="abbcabc", Pattern="abc"
    Output: [2, 3, 4]
    Explanation: The three anagrams of the pattern in the given string are "bca", "cab", and "abc".
         */
    /// </summary>
    public class StringAnagram
    {
        public static List<int> FindStringAnagrams(string str, string pattern)
        {

            var list = new List<int>();

            var dict = new Dictionary<char, int>(); 

            foreach(var ch in pattern)
            {
                if (!dict.TryAdd(ch, 1))
                {
                    dict[ch]++;
                }
            }

            int start = 0;

            int match = 0; 

            for (int end = 0; end < str.Length; end++)
            {

                if (dict.ContainsKey(str[end]))
                {
                    dict[str[end]]--; 

                    if(dict[str[end]] == 0)
                    {
                        match++; 
                    }
                }

                if(match == dict.Count)
                {
                    list.Add(start); 
                }

                //shrink window

                if(end >= pattern.Length - 1)
                {
                    if (dict.ContainsKey(str[start]))
                    {
                        if (dict[str[start]] == 0)
                            match--; // before putting the character back, decrement the matched count
                                       // put the character back for matching
                        dict[str[start]]++;
                    }
                    start++;
                }

              
            }

            return list; 
        }
    }
}
