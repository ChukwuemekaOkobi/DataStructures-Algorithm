using System;
using System.Collections.Generic;

namespace Patterns._8_DepthFirstSearch
{
    /// <summary>
    /// Root to Leaf Path
    /// </summary>
    public class PathSum
    {
        public static bool HasPathSum(TreeNode root, int sum)
        {
            return HasPathSumRecursive(root, sum);
        }

        private static bool HasPathSumRecursive(TreeNode root, int sum)
        {
            if(root == null)
            {
                return false; 
            }

            sum -= root.val;

            if (sum == 0 && root.left == null && root.right == null)
            {
                return true; 
            }

            return HasPathSumRecursive(root.left, sum) || HasPathSumRecursive(root.right, sum); 
        }

        //Solution 2 
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

    }
}
