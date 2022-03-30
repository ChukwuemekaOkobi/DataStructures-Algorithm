using Patterns._6_InPlaceReversalLinkedList;
using Patterns._8_DepthFirstSearch;
using Patterns._9_TwoHeaps;
using System;
using System.Linq;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            SlidingWindowMedian median = new();


            var item = median.FindSlidingWindowMedian(new int[]{ 1, 2, -1, 3, 5 }, 2);

            foreach(var i in item)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

    }

}
