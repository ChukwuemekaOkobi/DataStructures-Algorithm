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


            var number = new int[]  {1, 7, 7, 5, 9, 2, 12,3, 3};


  

            Console.WriteLine(PairsWithDifference2(number, 2));
    


        }

        //Stack Problems
        static bool IsBalanced (string item)
        {
            if(string.IsNullOrWhiteSpace(item))
            {
                return false;
            }
            string openbrackets = "[{<(";
            string closebrackets = "]}>)";

            Stack<char> stacks = new();
            
            foreach(var c in item)
            {
                if (openbrackets.Contains(c))
                {
                    stacks.Push(c);
                }

                if(closebrackets.Contains(c))
                {
                    if(stacks.Count <= 0)
                    {
                        return false;
                    }
                    char b = stacks.Pop();

                    if (openbrackets.IndexOf(b) == closebrackets.IndexOf(c))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            return stacks.Count == 0; 
        }

        static string Reversed (string item)
        {
            if(string.IsNullOrWhiteSpace(item))
            {
                return null; 
            }
            ArrayStack stack = new();

            foreach (var n in item)
            {
                stack.Push(n);
            }

            StringBuilder builder = new();

            while (!stack.IsEmpty())
                builder.Append(stack.Pop());

            return builder.ToString(); 
        }

        //Hash tables And Set
        static char FirstNoneRepeatingCharacter(string sentence)
        {
            var item = sentence.ToLower();
            Dictionary<char, int> CharPairs = new Dictionary<char, int>();


            foreach(var pair in item)
            {
                if (CharPairs.ContainsKey(pair))
                {
                    CharPairs[pair] +=1;
                }
                else
                {
                    CharPairs.Add(pair, 1);
                }
            }
       
            foreach(var pair in item)
            {
                if(CharPairs[pair] == 1)
                {
                    return pair;
                }
            }

            return char.MinValue;
            
        }

        static char FirstRepeatingCharacter(string sentence)
        {
            var item = sentence.ToLower();
     

            var Sets = new HashSet<char>();

            foreach (var pair in item)
            {
                if (Sets.Contains(pair))
                {
                    return pair;
                }
                else
                {
                    Sets.Add(pair);
                }
            }

            return char.MinValue;
        }

        static int MostFrequentNumber (int[] numbers)
        {
            Dictionary<int, int> numberCount = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (numberCount.ContainsKey(number))
                {
                    numberCount[number] += 1;
                }
                else
                {
                    numberCount.Add(number, 1);
                }
            }

            var highestFrequency = 0;
            var numbe = 0; 

            foreach (var number in numberCount.Keys)
            {
                if(numberCount[number] > highestFrequency)
                {
                    numbe = number;
                    highestFrequency = numberCount[number];
                }
            }

            return numbe;
        }
   
        //O(n^2) this loops through all values one after the other
        static int PairsWithDifference (int[] values, int diff)
        {
            int count = 0;
       
            var numbers = values.Distinct().ToArray();

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

        //implementing the using Sliding window O(n)
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

        
        static string TwoSums(int[] numbers, int diff)
        {
   
       

            return null;
        }
    }
}
