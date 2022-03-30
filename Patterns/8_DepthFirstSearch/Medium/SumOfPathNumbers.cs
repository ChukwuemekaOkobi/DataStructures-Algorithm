using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._8_DepthFirstSearch
{
    /// <summary>
    /// Given a binary tree where each node can only have a digit (0-9) value, 
    /// each root-to-leaf path will represent a number. Find the total sum of all the numbers represented by all paths.
    /// Example 1:

    /// Output: 408 Explanation: The sum of all path numbers: 17 + 192 + 199
    /// </summary>
    public class SumOfPathNumbers
    {

        public static int AllPathSum(TreeNode root)
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
}