using Patterns._1_SlidingWindow;
using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            var n = WordsConcatenation.FindWordConcatenation("catfoxcat", new[] { "cat", "fox" });

            foreach(var i in n)
            {
                Console.Write(i + " ,");
            }
        }
    }
}
