using System;
using System.Collections.Generic;

namespace Patterns.BreadthFirstSearch
{
    /// <summary>
    /// Given a binary tree, populate an array to represent the averages of all of its levels.
    /// </summary>
    public class Level
    {
        public static List<double> Average(TreeNode root)
        {
            List<double> result = new();

            Queue<TreeNode> queue = new();

            if (root == null)
            {
                return result;
            }

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;

                int sum = 0; 

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();

                    sum += node.val; 

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);

                }

                result.Add((double)sum / size);
              

            }
            return result;
        }

        public static List<double> Max (TreeNode root)
        {
            List<double> result = new();

            Queue<TreeNode> queue = new();

            if (root == null)
            {
                return result;
            }

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;

                int max = 0;

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();

                    max = Math.Max(node.val, max); 

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);

                }

                result.Add(max);


            }
            return result;
        }
    }


    public class NextLevelSuccessor
    {
        public static TreeNode Find(TreeNode root, int num)
        {
            Queue<TreeNode> queue = new();

            if (root == null)
            {
                return null; 
            }

            queue.Enqueue(root);

            while (queue.Count != 0)
            { 
                 TreeNode node = queue.Dequeue();

                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
                
                if (node.val == num)
                {
                    return queue.Peek(); 
                }

            }

            return null; 
        }
   
    }
}
