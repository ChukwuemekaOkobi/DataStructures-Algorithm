
using System;
using System.Linq;
using Patterns._10_SubSet;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {




            var item = Permutations.Find(new int[] { 1,5,3});

            foreach(var i in item)
            {
                Console.Write("[");
                foreach(var j in i)
                {
                    Console.Write(j+ " ");
                }

                Console.WriteLine("]");
               
            }

            Console.WriteLine();
        }

    }

}
