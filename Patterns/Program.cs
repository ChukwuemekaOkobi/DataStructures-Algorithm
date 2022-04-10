
using Patterns._13_TopKElements;
using Patterns._16_TopologicalSort;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {



            var list = MinimumHeightTree.MinHeight(new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 1, 3 } }); 

            foreach(var l in list)
            {
                Console.WriteLine(l); 
            }


        }

    }

}
