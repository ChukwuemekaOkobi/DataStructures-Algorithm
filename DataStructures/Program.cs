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

            BinaryTree tree = new BinaryTree();

            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);

            foreach(var y in tree.GetAncestors(4))
            {
                Console.WriteLine(y);
            }

           
        }


        static int Factorial(int num)
        {
            if(num == 0)
            {
                return 1;
            }
            
            return num * Factorial(--num);
    
        }

       

       

      
    }
}
