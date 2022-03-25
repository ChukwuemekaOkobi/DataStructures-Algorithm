
using ProblemsAndSolutions.Microsoft;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemsAndSolutions
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(LongestSubstring.Find("aaaabaabbaabbaaa"));


            PriorityQueue<int, int> queue = new PriorityQueue<int, int>(new Comparer());

            queue.Enqueue(1,1);
            queue.Enqueue(0, 0);
            queue.Enqueue(3, 3);


            Console.WriteLine(queue.Dequeue()); 
      
        }

        class Comparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x; 
            }
        }


    }
}