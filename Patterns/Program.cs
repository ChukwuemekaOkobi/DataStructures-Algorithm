
using System;
using System.Diagnostics;
using System.Linq;
using Patterns._11_ModifiedBinarySearch;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(NextLetter.SearchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'f'));
            Console.WriteLine(NextLetter.SearchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'd'));
            Console.WriteLine(NextLetter.SearchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'm'));
            Console.WriteLine(NextLetter.SearchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'g'));
        }

    }

}
