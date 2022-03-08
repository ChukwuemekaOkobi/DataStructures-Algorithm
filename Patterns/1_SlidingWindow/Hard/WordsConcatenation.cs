using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    /// QUESTION: Words Concatenation (hard)
    /*Given a string and a list of words, find all the starting indices of substrings in the given string 
      that are a concatenation of all the given words exactly once without any overlapping of words. 
      It is given that all words are of the same length.

        Example 1:

        Input: String="catfoxcat", Words=["cat", "fox"]
        Output: [0, 3]
        Explanation: The two substring containing both the words are "catfox" & "foxcat".
        Example 2:

        Input: String="catcatfoxfox", Words=["cat", "fox"]
        Output: [3]
        Explanation: The only substring containing both the words is "catfox".
    */
    /// </summary>
    public class WordsConcatenation
    {
        public static List<int> FindWordConcatenation(string str, string[] words)
        {
            var wordFrequencyMap = new Dictionary<string,int>();
            foreach (string word in words)
            {
                if (!wordFrequencyMap.TryAdd(word, 1))
                {
                    wordFrequencyMap[word]++;
                }
            }


            List<int> resultIndices = new();
            int wordsCount = words.Length, wordLength = words[0].Length;

            for (int i = 0; i <= str.Length - wordsCount * wordLength; i++)
            {
                var wordsSeen = new Dictionary<string,int>();
                for (int j = 0; j < wordsCount; j++)
                {
                    int nextWordIndex = i + j * wordLength;
                    // get the next word from the string
                    string word = str.Substring(nextWordIndex,  wordLength);
                    if (!wordFrequencyMap.ContainsKey(word)) // break if we don't need this word
                        break;

                    if (!wordsSeen.TryAdd(word, 1))
                    {
                        wordsSeen[word]++;
                    }
        
                    // no need to process further if the word has higher frequency than required 
                    if (wordsSeen[word] > wordFrequencyMap.GetValueOrDefault(word))
                        break;

                    if (j + 1 == wordsCount) // store index if we have found all the words
                        resultIndices.Add(i);
                }
            }

            return resultIndices;
        }
    }
}
