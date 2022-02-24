using Algorithms.Searching;
using Algorithms.Sorting;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] items = { 4, 6, 8, 0, 2,7,3 };


            Console.WriteLine(ExponentialSearch.Contains(items, 3));

            Console.WriteLine("[" + string.Join(",", items) + "]");

        }
    }
}