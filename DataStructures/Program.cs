using DataStructures;
using DataStructures.LinkedList;
using DataStructures.Stacks;
using DataStructures.Arrays;
using System.Collections.Generic;
using System.Text;
using System;
using DataStructures.Queues;
using DataStructures.HashTable;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {


            var sentence = "i am a good boy, i hate the cold";

            Console.WriteLine(FirstNoneRepeatingCharacter(sentence));
            Console.WriteLine(FirstRepeatingCharacter(sentence));
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
    }
}
