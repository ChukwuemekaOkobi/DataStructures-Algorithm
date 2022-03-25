using System.Collections.Generic;

namespace Patterns.BreadthFirstSearch
{
    /// <summary>
    /// Given a binary tree, return an array containing nodes in its right view. 
    /// The right view of a binary tree is the set of nodes visible when the tree is seen from the right side.
    /// </summary>
    public class TreeView
    {

        // return the last item in each level
        // left return the first item in each level
        public static List<int> Right(TreeNode root)
        {
            var list = new List<int>();
            if(root is null)
            {
                return list;  
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root); 

            while (queue.Count != 0)
            {
                int levelSize = queue.Count; 

                for(int i  = 0; i< levelSize; i++)
                {
                    var node = queue.Dequeue();

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right); 
                    
                    if(i == levelSize - 1)
                    {
                        list.Add(node.val);
                    }
                }

            }

            return list;
        }
    }
}
