using System.Collections.Generic;

namespace Patterns._14_KWayMerge
{
    /// <summary>
    /// Given ‘M’ sorted arrays, find the K’th smallest number among all the arrays.

    //Example 1:

    //Input: L1=[2, 6, 8], L2=[3, 6, 7], L3=[1, 3, 4], K=5
    //Output: 4
    //Explanation: The 5th smallest number among all the arrays is 4, this can be verified from
    //the merged list of all the arrays: [1, 2, 3, 3, 4, 6, 6, 7, 8]
    //Example 2:

    //Input: L1=[5, 8, 9], L2=[1, 7], K= 3
    //Output: 7
    //Explanation: The 3rd smallest number among all the arrays is 7.
    /// </summary>
    public class KthSmallestNumber
    {
  
        public static int Find(ListNode[] list, int k)
        {
            PriorityQueue<ListNode, int> queue = new();

            for (int i = 0; i < list.Length; i++)
            {
                queue.Enqueue(list[i], list[i].Value);
            }

        
            while (!queue.IsEmpty())
            {
                ListNode node = queue.Dequeue();
            
                if (node.Next != null)
                    queue.Enqueue(node.Next, node.Next.Value);
                k--;
                if (k == 0)
                    return node.Value; 
            }

            return -1;
        }

        public static int Find (List<int[]> list, int k)
        {
            PriorityQueue<Node, int> queue = new();

            for (int i = 0; i < list.Count; i++)
            {
                queue.Enqueue(new Node(0,i),list[i][0]);
            }

        
            while (!queue.IsEmpty())
            {
                Node node = queue.Dequeue();

                if (list[node.arrayIndex].Length-1 > node.elementIndex) {

                    var newNode = new Node(node.elementIndex + 1, node.arrayIndex);

                    queue.Enqueue(newNode, list[node.arrayIndex][newNode.elementIndex]);
                }
                k--;
                if (k == 0)
                    return list[node.arrayIndex][node.elementIndex];
            }
            return -1;
        }


        public static int FindMedian(List<int[]> list)
        {
            int n = 0; 

            foreach(var l in list)
            {
                n += l.Length; 
            }
            int k = n/2;

            return Find(list, k);
        }

        /// <summary>
        /// Merge all array to single sorted list
        /// </summary>

        public static List<int> SingleSortedList(List<int[]> list)
        {
            var result = new List<int>();

            PriorityQueue<Node, int> queue = new();

            for (int i = 0; i < list.Count; i++)
            {
                queue.Enqueue(new Node(0, i), list[i][0]);
            }


            while (!queue.IsEmpty())
            {
                Node node = queue.Dequeue();

                result.Add(list[node.arrayIndex][node.elementIndex]);

                if (list[node.arrayIndex].Length - 1 > node.elementIndex)
                {

                    node.elementIndex++;

                    queue.Enqueue(node, list[node.arrayIndex][node.elementIndex]);
                }
             
                   
            }

           return result; 
        }

   



    }
}
