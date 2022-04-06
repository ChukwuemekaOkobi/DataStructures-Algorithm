using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._14_KWayMerge
{
    public class ListNode
    {
        public int Value { get; set; }
        public ListNode Next { get; set; }

        public ListNode(int value)
        {
            Value = value;
        }
    }
    /// <summary>
    /// Given an array of ‘K’ sorted LinkedLists, merge them into one sorted list.
    //    Example 1:
    //    Input: L1=[2, 6, 8], L2=[3, 6, 7], L3=[1, 3, 4]
    //    Output: [1, 2, 3, 3, 4, 6, 6, 7, 8]
    //    Example 2:

    //    Input: L1=[5, 8, 9], L2=[1, 7]
    //    Output: [1, 5, 7, 8, 9]
    /// </summary>
    public class MergeSortedList
    {

        //NlogN + NLogN
        public static ListNode MergeBruteforce(ListNode[] list)
        {
            ListNode temp = list[0];

            PriorityQueue<ListNode, int> queue = new();

            for (int i = 1; i<= list.Length; i++)
            {
                while (temp.Next != null)
                {
                    queue.Enqueue(temp, temp.Value);
                    temp = temp.Next;
                }

                if(i == list.Length)
                {
                    break;
                }
                temp.Next = list[i];
            }

            temp = queue.Dequeue();
            ListNode result = temp; 

            while(!queue.IsEmpty())
            {
                var n = queue.Dequeue();
              
                temp.Next = n;

                temp = temp.Next; 
            }

            temp.Next = null;

            return result;
        }

        //NLogK
        public static  ListNode MergeKWay(ListNode[] list)
        {
            PriorityQueue<ListNode, int> queue = new();

            for(int i = 0; i < list.Length; i++)
            {
                queue.Enqueue(list[i], list[i].Value);
            }

            //this is also  correct
            //ListNode result = queue.Dequeue();
            //ListNode temp = result; 
       
            //while (!queue.IsEmpty())
            //{
            //    if (temp.Next != null)
            //    {
            //        queue.Enqueue(temp.Next, temp.Next.Value);
            //    }

            //    temp.Next = queue.Dequeue();

            //    temp = temp.Next;

            //}

            ListNode result = null, resultTail = null;
            while (!queue.IsEmpty())
            {
                ListNode node = queue.Dequeue();
                if (result == null)
                {
                    result = resultTail = node;
                }
                else
                {
                    resultTail.Next = node;
                    resultTail = resultTail.Next;
                }
                if (node.Next != null)
                    queue.Enqueue(node.Next, node.Next.Value);
            }

            return result; 
        }
    }
    public class Node
    {
        public int elementIndex;
        public int arrayIndex;

        public Node(int elementIndex, int arrayIndex)
        {
            this.elementIndex = elementIndex;
            this.arrayIndex = arrayIndex;
        }

    }
}
