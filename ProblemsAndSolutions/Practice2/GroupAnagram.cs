using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// Given an array of strings strs, group the anagrams together. You can return the answer in any order.

    //    An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
    //    Example 1:

    //Input: strs = ["eat","tea","tan","ate","nat","bat"]
    //    Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
    //Example 2:

    //Input: strs = [""]
    //    Output: [[""]]
    //Example 3:

    //Input: strs = ["a"]
    //    Output: [["a"]]
    /// </summary>
    public class GroupAnagram
    {
        /// <summary>
        /// Count chars  O(n * m)
        /// </summary>
       
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {

            Dictionary<int[], IList<string>> map = new (new MyEqualityComparer());

            for (int i = 0; i < strs.Length; i++)
            {
                var temp = CountStr(strs[i]);

                if (!map.ContainsKey(temp))
                {
                    IList<string> l = new List<string>
                    {
                        strs[i]
                    };
                    map.Add(temp, l);
                }
                else
                {
                    map[temp].Add(strs[i]);
                }
            }

            var list = new List<IList<string>>();


            foreach (var s in map)
            {
                list.Add(s.Value);
            }

            return list;
        }


        public static int[] CountStr(string str)
        {
            var c = new int[26];

            foreach(var ch in str)
            {
                c[ch - 'a']++;
            }

            return c;
        }

        /// <summary>
        /// sorting strings O(n * mlogm)
        /// </summary>

        public static IList<IList<string>> GroupAnagrams2(string[] strs)
        {

            Dictionary<string, IList<string>> map = new();

            for (int i = 0; i < strs.Length; i++)
            {
                var temp = SortString(strs[i]);

                if (!map.ContainsKey(temp))
                {
                    IList<string> l = new List<string>
                    {
                        strs[i]
                    };
                    map.Add(temp, l);
                }
                else
                {
                    map[temp].Add(strs[i]);
                }
            }


            return new List<IList<string>>(map.Values);
        }
        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
            //return  new string (input.OrderBy(c => c).ToArray());
        }
    }

    public class MyEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(int[] obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Length; i++)
            {
                unchecked
                {
                    result = result * 23 + obj[i];
                }
            }
            return result;
        }
    }




}

