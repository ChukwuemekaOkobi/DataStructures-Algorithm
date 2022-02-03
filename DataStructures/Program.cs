using DataStructures;
using DataStructures.LinkedList;
using DataStructures.Stacks;
using DataStructures.Arrays;
using System.Collections.Generic;
using System.Text;
using System;
using DataStructures.Queues;
using DataStructures.HashTable;
using System.Linq;
using System.Diagnostics;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {

            var number = new int[]  {1, 7, 5, 9, 2, 12,3, 3};

            Console.WriteLine(PairsWithDifference2(number, 2));

        }




        /// <summary>
        /// Brute force approach
        /// O(n^2) this loops through all values one after the other
        /// Does not handle duplicate pairs
        /// </summary>

        static int PairsWithDifference (int[] values, int diff)
        {
            int count = 0;

            var numbers = values;

            for(int i = 0; i < numbers.Length - 1; i++)
            {
                int shift = 1 + i;
                while(shift < numbers.Length)
                {
                    if(Math.Abs(numbers[i]-numbers[shift])  == diff)
                    {
                        count++; 
                    }
    
                    shift++;
                }
            }
            return count; 
        }

        /// <summary>
        /// implementing the using Sliding window O(n)
        /// Requires the array to be sorted in increasing order
        /// </summary>
        static int PairsWithDifference2(int[] numbers, int diff)
        {
            int count = 0;

            System.Array.Sort(numbers);

            int left = 0;
            int right = 0;
            while (right < numbers.Length)
            {
                if (numbers[right] - numbers[left] == diff)
                {
                    count++;
                    left++;
                    right++;
                }
                else if (numbers[right] - numbers[left] > diff)
                    left++;
    
                else 
                    right++;
            }
            return count;

        }

      
    }
}
