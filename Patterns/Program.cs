using Patterns._1_SlidingWindow;
using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(LongestSubArrayWithReplacement.Length( 3, new[] { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1 }));
        }
    }
}
