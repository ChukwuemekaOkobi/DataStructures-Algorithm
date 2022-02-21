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
using DataStructures.Trees;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {

            TrieWithHashMap tries = new TrieWithHashMap();

            tries.Insert("car");
            tries.Insert("care");

            tries.Insert("card");
            tries.Insert("egg");
            tries.Insert("careful");
            tries.Insert("elephant");
            tries.Insert("elizabeth");


            foreach(var item in tries.AutoComplete("el"))
            {
                Console.WriteLine(item);
            }

         
        }

    }
}
