using System;
using System.Collections.Generic;

namespace Patterns._8_DepthFirstSearch
{
    /// <summary>
    /// Root to Leaf Path
    /// </summary>
    public class PathSum
    {
       
        public static bool HasPath(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            // if the current node is a leaf and its value is equal to the sum, we've found a path
            if (root.val == sum && root.left == null && root.right == null)
                return true;

            // recursively call to traverse the left and right sub-tree
            // return true if any of the two recursive call return true
            return HasPath(root.left, sum - root.val) || HasPath(root.right, sum - root.val);
        }

        /// <summary>
        /// Return list of all paths that has a sum equal to sum
        /// </summary>
   
        public static List<List<int>> AllPathSumRecursion(TreeNode root, int sum)
        {
            var result = new List<List<int>>();

            var temp = new List<int>();

            FindPathsRecursive(root, sum, temp, result);

            return result; 
        }
        private static void FindPathsRecursive(TreeNode currentNode, int sum, List<int> currentPath,List<List<int>> allPaths)
        {
            if (currentNode == null)
                return;

            // add the current node to the path
            currentPath.Add(currentNode.val);

            // if the current node is a leaf and its value is equal to sum, save the current path
            if (currentNode.val == sum && currentNode.left == null && currentNode.right == null)
            {
                allPaths.Add(new List<int>(currentPath));
            }
            else
            {
                // traverse the left sub-tree
                FindPathsRecursive(currentNode.left, sum - currentNode.val, currentPath, allPaths);
                // traverse the right sub-tree
                FindPathsRecursive(currentNode.right, sum - currentNode.val, currentPath, allPaths);
            }

            // remove the current node from the path to backtrack, 
            // we need to remove the current node while we are going up the recursive call stack.
            currentPath.RemoveAt(currentPath.Count - 1);
        }
  

        /// <summary>
        /// Return the path in the largest sum
        /// </summary>
     
        public static List<int> PathWithMaxSum (TreeNode root)
        {
            int sum = 0;
            int max = 0; 
            List<int> current = new();
            List<int> maxPath = new ();

            RecursivePath(root, sum, current, ref max,ref maxPath);

            return maxPath;
        }

        private static void RecursivePath (TreeNode node,  int sum,  List<int> currentPath, ref int max, ref List<int> maxList)
        {
       
            if(node == null)
            {
                return; 
            }

            currentPath.Add(node.val);

            sum += node.val;
           
            // if the current node is a leaf check for sum
            if (node.left == null && node.right == null)
            {
                if(sum > max)
                {
                    maxList = new List<int>(currentPath);
                    max = sum; 
                }
            }
            else
            {
                
                // traverse the left sub-tree
                RecursivePath(node.left, sum , currentPath, ref max, ref maxList);
                // traverse the right sub-tree
                RecursivePath( node.right, sum, currentPath,ref max, ref maxList);
            }

            // remove the current node from the path to backtrack, 
            // we need to remove the current node while we are going up the recursive call stack.
            sum -= node.val;
            currentPath.RemoveAt(currentPath.Count - 1);

        }
    
        
        /// <summary>
        ///  Return the Max Sum from root to leaf
        /// </summary>
   
        public static int MaxPathSum (TreeNode root)
        {
            int k = 0; 
            int sum = 0;
            int max = MaxPathRecursive(root, sum, ref k);

            return max;

        }

        private static int MaxPathRecursive(TreeNode node, int sum, ref int max)
        {
            if(node == null)
            {
                return sum;
            }
            sum += node.val;


            return Math.Max(MaxPathRecursive(node.left, sum, ref max), MaxPathRecursive(node.right, sum, ref max));

        }
    }
}
