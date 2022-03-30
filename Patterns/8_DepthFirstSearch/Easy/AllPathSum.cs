using System.Collections.Generic;

namespace Patterns._8_DepthFirstSearch
{
    /// <summary>
    /// Given a binary tree and a number ‘S’, find all paths from root-to-leaf such that the sum of all the node values of each path equals ‘S’.
    /// </summary>
    public class AllPathSum
    {
        public static List<List<int>> FindAllPartsToSum (TreeNode root, int sum)
        {
            var list = new List<List<int>>();


            var temp = new List<int>();

            FindPathSumRecursive(root, list, temp, ref sum);

            return list; 
        }


        private static void FindPathSumRecursive(TreeNode root, List<List<int>> allList, List<int> temp,ref   int sum)
        {
            if (root == null)
            {
                return;
            }

            temp.Add(root.val);

            sum -= root.val;

            if (sum == 0)
            {
                allList.Add(new List<int>(temp));
            }
          
            FindPathSumRecursive(root.left, allList, temp, ref sum);
            FindPathSumRecursive(root.right, allList, temp, ref sum);

    
            sum += root.val;
            temp.RemoveAt(temp.Count-1); 
        }


        /// <summary>
        /// Solution 2
        /// </summary>

        public static List<List<int>> AllPathSumRecursion(TreeNode root, int sum)
        {
            var result = new List<List<int>>();

            var temp = new List<int>();

            FindPathsRecursive(root, sum, temp, result);

            return result;
        }
        private static void FindPathsRecursive(TreeNode currentNode, int sum, List<int> currentPath, List<List<int>> allPaths)
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




    }
}
