using System.Collections.Generic;

namespace Patterns._8_DepthFirstSearch
{
    /// <summary>
    /// Given a tree list all root to leaf paths 
    /// </summary>
    public class AllRootToLeafPath
    {

        public static List<List<int>> AllPaths (TreeNode root)
        {
            List<List<int>> allPaths = new();

            var current = new List<int>();

            AllPathsRecursive(root, current, allPaths);

            return allPaths; 

        }


        private static void AllPathsRecursive(TreeNode node, List<int> current, List<List<int>> AllPaths)
        {
            if(node == null)
            {
                return; 
            }

            current.Add(node.val);

            //if its leaf node

            if (node.left == null && node.right == null)
            {
                AllPaths.Add(new List<int>(current));
            }
          
                AllPathsRecursive(node.left, current, AllPaths);
                AllPathsRecursive(node.right, current, AllPaths);
            

            current.RemoveAt(current.Count-1);
        }
    }
}
