using System;
using System.Collections.Generic;

namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// A string s is called good if there are no two different characters in s that have the same frequency.
    /// return the min number of deletions required to make the string good.
    /// </summary>
    public class MinimumDeletion
    {
        public static int MakeCharUnique(string s)
        {
            //first track the frequency 
            // loop through the frequency in decending order 
            // ensure frequency is unique. 

            int count = 0;
            Dictionary<char, int> dict = new();

            HashSet<int> set = new();

            for (int i = 0; i < s.Length; i++)
            {

                if (!dict.TryAdd(s[i], 1))
                {
                    dict[s[i]]++;
                }
            }

            foreach (var val in dict)
            {

                if (set.Contains(val.Value))
                {

                    int v = val.Value;

                    while (set.Contains(v) && v != 0)
                    {
                        v--;
                        count++;
                    }
                
                        set.Add(v);
                }
                else
                {
                    set.Add(val.Value);
                }
            }

            return count;
        }

        public static int MinDeletions(string s)
        {
            // Store the frequency of each character
            int[] frequency = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                frequency[s[i] - 'a']++;
            }

            Array.Sort(frequency);

            int deleteCount = 0;
            // Maximum frequency the current character can have
            int maxFreqAllowed = s.Length;

            // Iterate over the frequencies in descending order
            for (int i = 25; i >= 0 && frequency[i] > 0; i--)
            {
                // Delete characters to make the frequency equal the maximum frequency allowed
                if (frequency[i] > maxFreqAllowed)
                {
                    deleteCount += frequency[i] - maxFreqAllowed;
                    frequency[i] = maxFreqAllowed;
                }
                // Update the maximum allowed frequency
                maxFreqAllowed = Math.Max(0, frequency[i] - 1);
            }

            return deleteCount;
        }
    }

    /// <summary>
    /// Longest Substring Without Three Contiguous Occurrences of Letter
    /// Example 1:
    //    Input: aabbaaaaabb
    //    Output: aabbaa
    //    Example 2:
    //    Input: aaaabaabbaabbaaa
    //    Output: aabbaabbaabbaa
    /// </summary>
    public class LongestSubstring
    {
        public static string Find(string str)
        {
            int freq = 1; 

            int max = 0; 

            int index = 0;

            int start = 0; 
            for(int end = 1; end < str.Length; end++)
            {

                if (str[end] == str[end - 1])
                {
                    freq++;

                }
                else
                {
                    freq = 1;

                }
                if (freq > 2)
                {
                    if (max < end - start)
                    {
                        index = start;
                        max = end - start;
                    }

                    start = end - 1;
                    freq--;
               
                }

            }

            return str.Substring(index,max); 
        }

        public static int FindCount(string str)
        {
            int freq = 1;

            int max = 0;

            int start = 0;
            for (int end = 1; end < str.Length; end++)
            {

                if (str[end] == str[end - 1])
                {
                    freq++;

                }
                else
                {
                    freq = 1;

                }
                if (freq > 2)
                {
                    if (max < end - start)
                    {
                       max = end - start;
                    }

                    max = Math.Max(max, end - start);

                    start = end - 1;
                    freq--;

                }

            }

            return max;
        }
    }


    /// <summary>
    /// String Without 3 Identical Consecutive Letters
    /// Example 1:
    //    Input: eedaaad
    //    Output: eedaad
    //    Explanation:
    //One occurrence of letter a is deleted.

    //Example 2:
    //Input: xxxtxxx
    //Output: xxtxx
    //Explanation:
    //Note that letter x can occur more than three times in the returned string if the occurrences are not consecutive.
    //    /// </summary>

    public class Without3ConsecutiveLetter
    {
        public static string Find(string str)
        {
            int frequency = 0; 

            for(int i = 1; i< str.Length; i++)
            {
                if(str[i] == str[i - 1])
                {
                    frequency++;
                }
                else
                {
                    frequency = 0; 
                }
                if(frequency >= 2)
                {
                   str =  str.Remove(i-1, 1);
                    frequency--;
                    i--;
                }
            }

            return str;
        }
    }
}

