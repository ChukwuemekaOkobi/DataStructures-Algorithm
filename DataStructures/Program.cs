using DataStructures;
using DataStructures.LinkedList;
using DataStructures.Stacks;
using System.Collections.Generic;
using System.Text;
using System;
using DataStructures.Queues;
using DataStructures.HashTable;
using System.Linq;
using System.Diagnostics;
using DataStructures.Tree;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Factorial(10));

        }


        static int Factorial(int num)
        {
            if(num > 1)
            {
                return num * Factorial(--num);
            }

            return 1;
        }

       

       

      
    }
}
