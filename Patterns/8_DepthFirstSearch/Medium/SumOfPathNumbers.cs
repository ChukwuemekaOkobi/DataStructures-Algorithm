using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._8_DepthFirstSearch
{
    /// <summary>
    /// 
    /// </summary>
    public class SumOfPathNumbers
    {
        /// <summary>
        /// Given a binary tree where each node can only have a digit (0-9) value, 
        /// each root-to-leaf path will represent a number. Find the total sum of all the numbers represented by all paths.
        /// Example 1:

        /// Output: 408 Explanation: The sum of all path numbers: 17 + 192 + 199
        /// </summary>

        public static int AllPathSumRecursion(TreeNode root)
        {

            return FindPathsRecursive(root, 0);
        }
        private static int FindPathsRecursive(TreeNode currentNode, int pathSum)
        {
            if (currentNode == null)
                return 0;


            pathSum = 10 * pathSum + currentNode.val;

            // if the current node is a leaf, return the current path sum.
            if (currentNode.left == null && currentNode.right == null)
            {
                return pathSum;
            }

            // if the current node is a leaf and its value is equal to sum, save the current path

            // traverse the left sub-tree
            return FindPathsRecursive(currentNode.left, pathSum) +
                     // traverse the right sub-tree
                     FindPathsRecursive(currentNode.right, pathSum);


        }

    }

    /// <summary>
    /// Given a binary tree and a number sequence, find if the sequence is present as a root-to-leaf path in the given tree
    /// </summary>
    public class PathWithSequence
    {
        public static bool FindPath(TreeNode root, int[] sequence)
        {

            return FindPathRecursive(root, sequence, 0);

        }


        private static bool FindPathRecursive(TreeNode currentNode, int[] sequence, int sequenceIndex)
        {

            if (currentNode == null)
                return false;

            if (sequenceIndex >= sequence.Length || currentNode.val != sequence[sequenceIndex])
                return false;

            // if the current node is a leaf, add it is the end of the sequence, we have found a path!
            if (currentNode.left == null && currentNode.right == null && sequenceIndex == sequence.Length - 1)
                return true;

            // recursively call to traverse the left and right sub-tree
            // return true if any of the two recursive call return true
            return FindPathRecursive(currentNode.left, sequence, sequenceIndex + 1)
                || FindPathRecursive(currentNode.right, sequence, sequenceIndex + 1);
        }


    }
}