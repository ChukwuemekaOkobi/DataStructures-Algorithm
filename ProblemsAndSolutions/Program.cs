
using ProblemsAndSolutions.Microsoft;
using System;

namespace ProblemsAndSolutions
{
    class Program
    {
        static void Main(string[] args)
        {

           Console.WriteLine(PairingInteger.IsPairPossible(new int[] { 4, 2, 4, 2 }));
           Console.WriteLine(PairingInteger.IsPairPossibleSet(new int[] { 7,7, 2 }));
        }
    }
}