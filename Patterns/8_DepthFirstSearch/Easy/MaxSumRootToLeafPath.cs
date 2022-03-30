using System;
using System.Collections.Generic;

namespace Patterns._8_DepthFirstSearch
{
    /// <summary>
    /// Find the path with the max sum
    /// </summary>
    public class MaxSumRootToLeafPath
    {
        public static List<int> PathWihMaxSum(TreeNode root)
        {
            var list = new List<int>();

            var current = new List<int>(); 

            int Max = int.MinValue;
            int sum = 0;

            MaxPathSumRecursive(root, current, sum, ref Max, ref list);

            return list; 
        }

        private static void MaxPathSumRecursive(TreeNode node, List<int> current, int currentSum, ref int MaxSum, ref List<int> MaxPath)
        {
            if(node == null)
            {
                return; 
            }

            currentSum += node.val;

            current.Add(node.val); 

            if(node.left == null && node.right == null)
            {
                if(MaxSum < currentSum)
                {
                    MaxSum = currentSum;

                    MaxPath = new List<int>(current); 
                }
            }
            else
            {
                MaxPathSumRecursive(node.left, current, currentSum, ref MaxSum, ref MaxPath);
                MaxPathSumRecursive(node.right, current, currentSum, ref MaxSum, ref MaxPath);
            }

            currentSum -= node.val; 
            current.RemoveAt(current.Count - 1);

        }

        /// <summary>
        ///  Return the Max Sum from root to leaf
        /// </summary>

        public static int MaxPathSum(TreeNode root)
        {

            int sum = 0;
            int max = MaxPathRecursive(root, sum);

            return max;

        }

        private static int MaxPathRecursive(TreeNode node, int sum)
        {
            if (node == null)
            {
                return sum;
            }
            sum += node.val;


            return Math.Max(MaxPathRecursive(node.left, sum), MaxPathRecursive(node.right, sum));

        }
    }
}
