using Algorithms.Searching;
using Algorithms.Sorting;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] items = { 4, 6, 8, 0, 2,7,3,3 };

            SelectionSort.Sort(items);

            foreach(var n in items)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();


        }
    }
}