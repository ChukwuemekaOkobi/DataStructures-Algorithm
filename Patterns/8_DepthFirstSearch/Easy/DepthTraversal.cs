using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._8_DepthFirstSearch
{
    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode next { get; set; }

        public TreeNode(int x)
        {
            val = x;
        }
    }
    public class DepthTraversal
    {
        public static void TraverseIteration(TreeNode root)
        {
           if(root == null)
            {
                return;
            }

            Stack<TreeNode> stack = new();

            stack.Push(root); 

            while(stack.Count != 0)
            {
                var node = stack.Pop();

                Console.WriteLine(node.val);

                if (node.left != null)
                    stack.Push(node.left);
                if (node.right != null)
                    stack.Push(node.right);
            }
        }

        public static void TraverseRecursion(TreeNode root)
        {
            Depth(root);
        }

        private static void Depth(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.val);
            Depth(node.left);
            Depth(node.right);
        }
    }
}
