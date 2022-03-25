using Patterns._6_InPlaceReversalLinkedList;
using Patterns._8_DepthFirstSearch;
using System;
using System.Collections.Generic;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {


            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(1);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(3);
            root.right.left.left = new TreeNode(5);


            Console.WriteLine(MaximumDistinctPath.FindMaxDictinctPath(root));
            

        }


        public class Comparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }

    }

}
