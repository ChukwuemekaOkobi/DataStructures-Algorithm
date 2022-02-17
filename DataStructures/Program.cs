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

            Heap heap = new Heap();

            heap.Insert(45);
            heap.Insert(23);
            heap.Insert(89);
            heap.Insert(67);
            heap.Insert(21);
            heap.Insert(5);
            heap.Insert(100);
            heap.Insert(74);

            heap.Remove();

            Console.WriteLine(heap);
        }

    }
}
