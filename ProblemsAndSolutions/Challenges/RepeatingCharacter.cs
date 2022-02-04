using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Challenges
{
    /// <summary>
    /// Contains Three Challenges 
    /// 1. Find the First Non-Repeating or Unique Character in a String 
    /// 2. Find the First Repeating Character in a String 
    /// 3. Find the Most Frequency number in an Array
    /// </summary>
    class RepeatingCharacter
    {
        /// <summary>
        /// First None Repeating or Unique Character 
        /// using a Dictionary/ HashMap
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public char FirstNoneRepeatingOrUniqueCharacter(string sentence)
        {
            var item = sentence.ToLower();
            Dictionary<char, int> CharPairs = new Dictionary<char, int>();


            foreach (var pair in item)
            {
                if (CharPairs.ContainsKey(pair))
                {
                    CharPairs[pair] += 1;
                }
                else
                {
                    CharPairs.Add(pair, 1);
                }
            }

            foreach (var pair in item)
            {
                if (CharPairs[pair] == 1)
                {
                    return pair;
                }
            }

            return char.MinValue;

        }

        /// <summary>
        /// First repeating Character 
        /// using a Sets
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public char FirstRepeatingCharacter(string sentence)
        {
            var item = sentence.ToLower();


            var Sets = new HashSet<char>();

            foreach (var pair in item)
            {
                if (Sets.Contains(pair))
                {
                    return pair;
                }
                else
                {
                    Sets.Add(pair);
                }
            }

            return char.MinValue;
        }

        /// <summary>
        /// Most Frequent Number in an Array
        /// Use Dictionary to keep track of items and their count 
        /// O(n)
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int MostFrequentNumber(int[] numbers)
        {
            Dictionary<int, int> numberCount = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (numberCount.ContainsKey(number))
                {
                    numberCount[number] += 1;
                }
                else
                {
                    numberCount.Add(number, 1);
                }
            }

            var highestFrequency = 0;
            var numbe = 0;

            foreach (var number in numberCount.Keys)
            {
                if (numberCount[number] > highestFrequency)
                {
                    numbe = number;
                    highestFrequency = numberCount[number];
                }
            }

            return numbe;
        }

    }
}
