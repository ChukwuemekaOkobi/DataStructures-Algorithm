using System.Collections.Generic;

namespace Patterns.BreadthFirstSearch
{
    /// <summary>
    /// Find the max and min depth of a tree
    /// </summary>
    public class Depth
    {
        public static int Minimum(TreeNode root)
        {
            if(root== null)
            {
                return 0; 
            }
            Queue<TreeNode> queue = new();

            queue.Enqueue(root);

            int count = 0; 

            while (queue.Count != 0)
            {
                int size = queue.Count;

                count++; 

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                     

                    if(node.left == null && node.right == null)
                    {
                        return count;
                    }

                    if (node.left != null)
                        queue.Enqueue(node.left);
                   
                    if (node.right != null)
                        queue.Enqueue(node.right);
                   

                }

            }
            return count;
        }
    
        public static int Maximum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            Queue<TreeNode> queue = new();

            queue.Enqueue(root);

            int count = 0;

            while (queue.Count != 0)
            {
                int size = queue.Count;

                count++;

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (node.left != null)
                        queue.Enqueue(node.left);

                    if (node.right != null)
                        queue.Enqueue(node.right);

                }

            }
            return count;

        }
    }
}
