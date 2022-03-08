using Patterns._1_SlidingWindow;
using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

           var n = StringAnagram.FindStringAnagrams("aabcec",  "abc");

            foreach(var a in n)
            {
                Console.Write(a + ", ");
            }
        }
    }
}
