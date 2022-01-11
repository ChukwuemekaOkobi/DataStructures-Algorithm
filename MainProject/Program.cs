using DataStructures;
using DataStructures.LinkedList;
using DataStructures.Stacks;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {

            DoubleLinkedList list = new ();

            list.AddLast(23);
            list.AddLast(45);
            list.AddLast(34);
            list.AddLast(87);
            list.AddLast(14);

            list.PrintAll();

            Console.WriteLine(" ----- " + list.Count);

            list.RemoveLast();

            list.PrintAll();

            Console.WriteLine(" ----- " + list.Count);

        }

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
    }
}
