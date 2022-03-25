using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.BreadthFirstSearch
{

    /// <summary>
    /// Traverse the tree level order 
    /// add a list of nodes at every level
    /// </summary>

    public class BreadthFirstTraversal
    {
        public static List<List<int>> TraverseLevelOrder(TreeNode root)
        {
            List<List<int>> result = new();

            Queue<TreeNode> queue = new ();

            if (root == null)
            {
                return result;
            }

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;

                var list = new List<int>();

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();


                    list.Add(node.val);

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);

                }

                    result.Add(list);
                
              
            }
            return result;
        }


        public static List<List<int>> TraverseReverseLevelOrder (TreeNode root)
        {
            List<List<int>> result = new();

            Queue<TreeNode> queue = new();

            if(root == null)
            {
                return result; 
            }

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;

                var list = new List<int>();

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();

                   
                    list.Add(node.val);

                    if(node.left != null)
                        queue.Enqueue(node.left);
                    if(node.right != null)
                        queue.Enqueue(node.right);
                    
                }

                if (list.Count > 0)
                {
                    result.Insert(0, list);
                }

            }
            return result;

        }


        public static List<List<int>> TraverseRecursion(TreeNode root)
        {
            var result = new List<List<int>>();

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            Breadth(queue, result); 

            return result; 
        }

        private static void Breadth (Queue<TreeNode> queue,  List<List<int>> list)
        {

            if(queue.Count == 0)
            {
                return; 
            }
            var temp = new List<int>();

            int size = queue.Count; 

            for(int i = 0; i< size; i++)
            {
                var next =  queue.Dequeue();

                temp.Add(next.val);

                if (next.left != null)
                    queue.Enqueue(next.left);
                if (next.right != null)
                    queue.Enqueue(next.right); 
            }

            list.Add(temp);

            Breadth(queue, list); 

        }
    }

    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode next { get; set; }

        public TreeNode(int x)
        {
            val = x;
        }
    }
}
