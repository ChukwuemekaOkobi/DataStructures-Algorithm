using System.Collections.Generic;

namespace Patterns.BreadthFirstSearch
{
    /// <summary>
    /// Given a binary tree, connect each node with its level order successor. 
    /// The last node of each level should point to a null node.
    /// </summary>
    public class ConnectLevelSibling
    {
        public static void Connect(TreeNode root)
        {

            Queue<TreeNode> queue = new();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;

                List<TreeNode> result = new();

                TreeNode previousNode = null;

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (previousNode != null)
                        previousNode.next = node;
                    previousNode = node;


                    result.Add(node);

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);

                }

                //for(int i = 0; i< result.Count; i++)
                //{
                //    result[i].next = i + 1 == result.Count ? null : result[i + 1];
                //}

            }

        }
    

        public static void ConnectAll(TreeNode root)
        {

            Queue<TreeNode> queue = new();

            queue.Enqueue(root);
            TreeNode previousNode = null;

            while (queue.Count != 0)
            {
                    TreeNode node = queue.Dequeue();

                    if (previousNode != null)
                        previousNode.next = node;
                    previousNode = node;

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);


            }
        }
    
    }
}
