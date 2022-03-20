using System.Collections.Generic;

namespace ProblemsAndSolutions.Microsoft
{
    public class TopKFrequentWord
    {
        public static List<string> TopKWords(string[] words, int k)
        {
            var list = new List<string>();
            if(words.Length == 0)
            { return list; 
            }
            var dict = new Dictionary<string, int>(); 

            foreach(var word in words)
            {
                if (!dict.TryAdd(word, 1))
                {
                    dict[word]++;
                }
            }

            PriorityQueue<string, (int, string)> queue = new(new PriorityComparer());


            foreach (var item in dict)
            {
                queue.Enqueue(item.Key, (item.Value, item.Key));

                if(queue.Count > k)
                {
                    queue.Dequeue();
                }
            }

            while (queue.Count != 0)
            {
                list.Add(queue.Dequeue());
            }

            list.Reverse();

            return list; 
        }


        public class PriorityComparer : IComparer<(int, string)>
        {
            public int Compare((int, string) x, (int, string) y)
            {
                if(x.Item1 == y.Item1)
                {
                    return y.Item2.CompareTo(x.Item2);
                }

                return x.Item1 - y.Item1; 
            }
        }

    }

}


