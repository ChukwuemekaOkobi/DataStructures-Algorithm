using System.Collections.Generic;

namespace Patterns._8_DepthFirstSearch
{
    /// <summary>
    /// count all paths that sum to a number s from root to leaf
    /// </summary>
    public class CountAllPathSum
    {
        public static int CountPaths(TreeNode root, int S)
        {
            List<int> currentPath = new();
            int count = 0;

            CountPathRecursive(root, S, currentPath, ref count);
            return count;
            //return CountPathsRecursive(root, S, currentPath);
        }

        private static int CountPathsRecursive(TreeNode currentNode, int S, List<int> currentPath)
        {
            if (currentNode == null)
                return 0;

            // add the current node to the path
            currentPath.Add(currentNode.val);
            int pathCount = 0, pathSum = 0;
            // find the sums of all sub-paths in the current path list
            for (int i = currentPath.Count - 1; i >= 0; i--)
            {
                pathSum += currentPath[i];
                // if the sum of any sub-path is equal to 'S' we increment our path count.
                if (pathSum == S)
                {
                    pathCount += 1;
                }
            }

            // traverse the left sub-tree
            pathCount += CountPathsRecursive(currentNode.left, S, currentPath);
            // traverse the right sub-tree
            pathCount += CountPathsRecursive(currentNode.right, S, currentPath);

            // remove the current node from the path to backtrack, 
            // we need to remove the current node while we are going up the recursive call stack.
            currentPath.RemoveAt(currentPath.Count - 1);

            return pathCount;
        }
    
       
        private static void CountPathRecursive(TreeNode treeNode, int s, List<int> currentPath, ref int count)
        {
            if(treeNode == null)
            {
                return; 
            }

            currentPath.Add(treeNode.val);
            int tempSum = 0; 

            // check if node equal sums; 

            for(int i = currentPath.Count-1; i>=0; i--)
            {
                tempSum += currentPath[i]; 

                if(tempSum == s)
                {
                    count++; 
                }
            }

            CountPathRecursive(treeNode.left, s, currentPath, ref count);
            CountPathRecursive(treeNode.right, s, currentPath, ref count);

            //remove last item when bubbling up the recursive path
            currentPath.RemoveAt(currentPath.Count-1);
        }
    }
}