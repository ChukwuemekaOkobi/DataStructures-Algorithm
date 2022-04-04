
using System;
using System.Diagnostics;
using System.Linq;
using Patterns._11_ModifiedBinarySearch;
using static Patterns._11_ModifiedBinarySearch.InfiniteArray;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayReader reader = new ArrayReader(new int[] { 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 });

            Console.WriteLine(InfiniteArray.Search(reader, 78));

        }

    }

}
