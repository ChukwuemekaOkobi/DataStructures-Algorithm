using Patterns._6_InPlaceReversalLinkedList;
using Patterns.BreadthFirstSearch;
using System;
using System.Collections.Generic;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            Console.WriteLine("Tree Minimum Depth: " + Depth.Minimum(root));
            root.left.left = new TreeNode(9);
            root.right.left.left = new TreeNode(11);
            Console.WriteLine("Tree Minimum Depth: " + Depth.Maximum(root));

            var ad = BreadthFirstTraversal.TraverseRecursion(root);

            foreach(var n in ad)
            {
                foreach(var s in n)
                {
                    Console.Write(s + " "); 
                }
                Console.WriteLine(); 
            }


           
        }

    }

}
