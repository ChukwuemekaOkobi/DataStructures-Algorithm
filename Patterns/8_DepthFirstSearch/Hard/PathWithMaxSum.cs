using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._8_DepthFirstSearch
{
    public class PathWithMaxSum
    {
        private static int globalMaximumSum;

        public static int FindPath(TreeNode root)
        {

            globalMaximumSum = int.MinValue;
            FindMaximumPathSumRecursive(root);
            return globalMaximumSum;
        }

        private static int FindMaximumPathSumRecursive(TreeNode currentNode)
        {
            if (currentNode == null)
                return 0;

            int maxPathSumFromLeft = FindMaximumPathSumRecursive(currentNode.left);
            int maxPathSumFromRight = FindMaximumPathSumRecursive(currentNode.right);

            // ignore paths with negative sums, since we need to find the maximum sum we should
            // ignore any path which has an overall negative sum.
            maxPathSumFromLeft = Math.Max(maxPathSumFromLeft, 0);
            maxPathSumFromRight = Math.Max(maxPathSumFromRight, 0);

            // maximum path sum at the current node will be equal to the sum from the left subtree +
            // the sum from right subtree + val of current node
            int localMaximumSum = maxPathSumFromLeft + maxPathSumFromRight + currentNode.val;

            // update the global maximum sum
            globalMaximumSum = Math.Max(globalMaximumSum, localMaximumSum);

            // maximum sum of any path from the current node will be equal to the maximum of 
            // the sums from left or right subtrees plus the value of the current node
            return Math.Max(maxPathSumFromLeft, maxPathSumFromRight) + currentNode.val;
        }
    }
}
