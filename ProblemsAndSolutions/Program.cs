using ProblemsAndSolutions.Challenges;
using System;

namespace ProblemsAndSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] item = { 4, 72, 8, 4, 3, 6, 5, 83, 45, 42, 98 };

            Console.WriteLine(KthLargestItem.FindKthItem(item, 12));
        }
    }
}
