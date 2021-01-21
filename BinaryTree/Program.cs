using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BinaryTree tree = new BinaryTree
            {
                Base = new Node(23)
            };

            tree.Base.Left = new Node(24);
            tree.Base.Right = new Node(25);

            Console.WriteLine(tree.Base.Value);
            Console.WriteLine(tree.Base.Left.Value);
            Console.WriteLine(tree.Base.Right.Value); 
        }
    }
}
