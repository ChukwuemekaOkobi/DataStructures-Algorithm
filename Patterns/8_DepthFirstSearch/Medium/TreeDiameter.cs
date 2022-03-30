using System;

namespace Patterns._8_DepthFirstSearch
{
    /// <summary>
    /// Find the diameter of a tree, which is the longest path from leaf node to leaf node
    /// </summary>
    public class TreeDiameter
    {

        private static int treeDiameter = 0;

        public static int FindDiameter(TreeNode root)
        {
            CalculateHeight(root);
           
            return treeDiameter;
        }

        private static int CalculateHeight(TreeNode currentNode)
        {
            if (currentNode == null)
                return 0;

            int leftTreeHeight = CalculateHeight(currentNode.left);
            int rightTreeHeight = CalculateHeight(currentNode.right);

            // if the current node doesn't have a left or right subtree, we can't have
            // a path passing through it, since we need a leaf node on each side

            // (currentNode.left != null && currentNode.right != null
            if (leftTreeHeight != 0 && rightTreeHeight != 0)  
            {

                // diameter at the current node will be equal to the height of left subtree +
                // the height of right sub-trees + '1' for the current node
                int diameter = leftTreeHeight + rightTreeHeight + 1;

                // update the global tree diameter
                treeDiameter = Math.Max(treeDiameter, diameter);
            }

            // height of the current node will be equal to the maximum of the heights of
            // left or right subtrees plus '1' for the current node
            return Math.Max(leftTreeHeight, rightTreeHeight) + 1;
        }


    }
}