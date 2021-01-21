using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace LinkedList
{
    /// <summary>
    /// Linked List data structure implementation using C# 
    /// Data 22nd June 2020.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
      
            LinkedList List = new LinkedList();

            Console.WriteLine("------");


            var Limit = new Random().Next(2, 5);

            for (int i = 0; i < Limit; i++)
            {
                List.AddFirst(new Random().Next(24));
                List.AddLast(new Random().Next(30));
            }

            Console.WriteLine(" Count " + List.Count);

            Console.WriteLine("First Value is {0}", List.Head.Value);
            Console.WriteLine("Last Value is {0}", List.Last.Value);
            List.PrintAll();

            List.AddBefore(List.Head.Next.Next, new Random().Next(38));
            List.AddAfter(List.Head.Next.Next, new Random().Next(54));

            Console.WriteLine(" Count " + List.Count);

            Console.WriteLine("First Value is {0}", List.Head.Value);
            Console.WriteLine("Last Value is {0}", List.Last.Value);
            List.PrintAll();

            List.RemoveNode(List.Head.Next.Next);
            Console.WriteLine(" Count " + List.Count);

            Console.WriteLine("First Value is {0}", List.Head.Value);
            Console.WriteLine("Last Value is {0}", List.Last.Value);
            List.PrintAll();
            Console.WriteLine("Hello World!");
            
        }
    }


}
