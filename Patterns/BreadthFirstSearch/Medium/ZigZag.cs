using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.BreadthFirstSearch
{
    /// <summary>
    /// Given a binary tree, populate an array to represent its zigzag level order traversal.
    /// You should populate the values of all nodes of the first level from left to right, 
    /// then right to left for the next level and keep alternating in the same manner for the following levels.
    /// </summary>
    public class ZigZag
    {
        public static List<List<int>> Traverse(TreeNode root)
        {

            var result = new List<List<int>>();

            if(root == null)
            {
                return result; 
            }


           
            Queue<TreeNode> queue = new();

            queue.Enqueue(root);
  
            while (queue.Count != 0)
            {

                var temp = new List<int>();

                int size = queue.Count;
                //even level = l to right; 
                //odd level = r to l; 
                bool LeftToRight = true;
                for (int i = 0; i<size; i++)
                {
                    var node = queue.Dequeue();
                   
                   
                    if (LeftToRight)
                        temp.Add(node.val); 
                    else
                        temp.Insert(0, node.val);

                    if (node.left != null)
                            queue.Enqueue(node.left);
                        if (node.right != null)
                            queue.Enqueue(node.right);
                  

                }
                _ = !LeftToRight; 

                result.Add(temp); 

            }
            

            return result; 
        }
    }
}
