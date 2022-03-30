namespace Patterns._8_DepthFirstSearch
{
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