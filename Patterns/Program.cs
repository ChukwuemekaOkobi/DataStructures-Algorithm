using Patterns._1_SlidingWindow;
using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine(MaximumSumSubarray.BruteForce(new int[] { 2, 1, 5, 1, 3, 2 }, 3));
            Console.WriteLine(MaximumSumSubarray.SlidingWindow(new int[] { 2, 1, 5, 1, 3, 2 }, 3));

        }
    }
}
