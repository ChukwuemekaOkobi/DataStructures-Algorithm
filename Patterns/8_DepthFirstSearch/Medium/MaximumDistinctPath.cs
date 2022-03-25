using System;
using System.Collections.Generic;

namespace Patterns._8_DepthFirstSearch
{
    /// <summary>
    /// Find the number of nodes on the longest distinct path that starts at the root in a binary tree.
    /// Root to leaf path with maximum distinct nodes
    /// </summary>
    public class MaximumDistinctPath
    {
        public static int FindMaxDictinctPath (TreeNode node)
        {
            int max = 0;

            HashSet<int> set = new();

            DepthSearch(node, ref max, set); 

            return max; 
        }

        public static void DepthSearch(TreeNode node, ref int max, HashSet<int> set)
        {
            if(node == null  || set.Contains(node.val))
            {
                return; 
            }

            set.Add(node.val);

            max = Math.Max(max, set.Count);


            DepthSearch(node.left, ref max,  set);

            DepthSearch(node.right, ref max, set); 

            //back track 

            set.Remove(node.val); 

        }
    }
}