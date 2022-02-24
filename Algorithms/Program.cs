using Algorithms.Sorting;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] items = { 4, 5, 1, 6, 8, 0, 2 };


            BucketSort.Sort(items, 3);

            foreach(var i in items)
            {
                Console.Write(i + ",");
            }

        }
    }
}