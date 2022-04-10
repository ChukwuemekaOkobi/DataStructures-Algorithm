using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns._16_TopologicalSort
{
    /// <summary>
    /// There is a dictionary containing words from an alien language for which we don’t know the ordering of the alphabets. 
    /// Write a method to find the correct order of the alphabets in the alien language. 
    /// It is given that the input is a valid dictionary and there exists an ordering among its alphabets.

    //    Example 1:

    //Input: Words: ["ba", "bc", "ac", "cab"]
    //    Output: bac
    //    Explanation: Given that the words are sorted lexicographically by the rules of the alien language, so
    //from the given words we can conclude the following ordering among its characters:

    //1. From "ba" and "bc", we can conclude that 'a' comes before 'c'.
    //2. From "bc" and "ac", we can conclude that 'b' comes before 'a'

    //From the above two points, we can conclude that the correct character order is: "bac"
    //Example 2:

    //Input: Words: ["cab", "aaa", "aab"]
    //    Output: cab
    //    Explanation: From the given words we can conclude the following ordering among its characters:

    //1. From "cab" and "aaa", we can conclude that 'c' comes before 'a'.
    //2. From "aaa" and "aab", we can conclude that 'a' comes before 'b'

    //From the above two points, we can conclude that the correct character order is: "cab"
    //Example 3:

    //Input: Words: ["ywx", "wz", "xww", "xz", "zyy", "zwz"]
    //    Output: ywxz
    //    Explanation: From the given words we can conclude the following ordering among its characters:

    //1. From "ywx" and "wz", we can conclude that 'y' comes before 'w'.
    //2. From "wz" and "xww", we can conclude that 'w' comes before 'x'.
    //3. From "xww" and "xz", we can conclude that 'w' comes before 'z'
    //4. From "xz" and "zyy", we can conclude that 'x' comes before 'z'
    //5. From "zyy" and "zwz", we can conclude that 'y' comes before 'w'

    //From the above five points, we can conclude that the correct character order is: "ywxz"
    /// </summary>
    public class AlienDictionary
    {
        public static string FindOrder(string[] words)
        {
            int length = words.Length;

            //build graph
            Dictionary<char, HashSet<char>> graph = new Dictionary<char, HashSet<char>>();
            Dictionary<char, int> dependencies = new Dictionary<char, int>();

            for (int i = 1; i < length; i++)
            {
                string first = words[i - 1];
                string second = words[i]; 

                for(int j = 0; j< Math.Min(first.Length, second.Length); j++)
                {
                    if (first[j] != second[j])
                    {
                        char parent = first[j];
                        char child = second[j]; 
                        if (!graph.ContainsKey(parent))
                        {
                            graph.Add(parent, new HashSet<char>());
                            dependencies.Add(parent, 0);
                        }
                        if (!graph.ContainsKey(child))
                        {
                            graph.Add(child, new HashSet<char>());
                            dependencies.Add(child, 0);
                        }

                        if (!graph[parent].Contains(child))
                        {
                            graph[parent].Add(child);
                            dependencies[child]++;
                        }
                        break;
                    }
                }

            }

            //sort 

            Queue<char> queue = new Queue<char>();

            StringBuilder builder = new StringBuilder();

            foreach (var item in dependencies)
            {
                if(item.Value == 0)
                {
                    queue.Enqueue(item.Key); 
                }
            }

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

               builder.Append(node);

                var children = graph[node];

                foreach(var child in children)
                {
                    dependencies[child]--; 

                    if(dependencies[child] == 0)
                    {
                        queue.Enqueue(child); 
                    }
                }

            }


            return builder.ToString(); 
        }
    }
}
