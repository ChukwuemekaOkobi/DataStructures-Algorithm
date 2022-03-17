using System;

namespace Patterns._6_InPlaceReversalLinkedList
{
    /// <summary>
    /// Reverse the first ‘k’ elements of a given LinkedList.

    /// Start from the first element and reserve k items 
    /// </summary>
    public class ReverseKElement
    {
        /// <summary>
        /// Problem 2: Given a LinkedList with ‘n’ nodes, reverse it based on its size in the following way:

        //If ‘n’ is even, reverse the list in a group of n/2 nodes.
        //If n is odd, keep the middle node as it is, reverse the first ‘n/2’ nodes and reverse the last ‘n/2’ nodes.

        //Solution: When ‘n’ is even we can perform the following steps:
        //Reverse first ‘n/2’ nodes: head = reverse(head, head.value, n/2)
        //Reverse last ‘n/2’ nodes: head = reverse(head, n/2 + 1, n)

        //When ‘n’ is odd, our algorithm will look like:

        //head = reverse(head, 1, n/2)
        //head = reverse(head, n/2 + 2, n)
        /// </summary>


        public static ListNode ReverseListBaseOfEvenOrOdd(ListNode head, int n)
        {

            head = ReverseFirstK(head, n / 2);
            head = ReverseLastKElement(head, n / 2);

            return head;
        }
        
        
        public static ListNode ReverseFirstK(ListNode head, int k)
        {
            //reverse from the required node
            head = ReverseSub(head, k);
          
            return head;
        }



        /// <summary>
        ///  Given a linked list reverse the last K elements 
        ///  Need fast and slow pointer
        /// </summary>

        public static ListNode ReverseLastKElement(ListNode head, int k)
        {
            ListNode fast = head;
            ListNode KthNodeFromLast = head;
            ListNode previous = null;

            int count = 1;

            while (fast != null && fast.next != null)
            {
                if (count >= k)
                {
                    previous = KthNodeFromLast;
                    KthNodeFromLast = KthNodeFromLast.next;
                }
                fast = fast.next;
                count++;
            }

            previous.next = ReverseSub(KthNodeFromLast.next, k);

            return head;
        }

        /// <summary>
        ///  Given a linked List reverse the first k elements from a given node
        /// </summary>

        public static ListNode ReverseNodetillK (ListNode head, int node, int k)
        {
            ListNode previous = null;
            ListNode current = head;

            //loop through the list and keep track of the previous node
            while (current != null)
            {
                if (current.value == node)
                {
                    //reverse from the required node till count k
                    ListNode next = ReverseSub(current, k);

                    if (previous == null)
                    {  //if previous is still null then p is the head node
                        //assign the new head to the output of reverseSub
                        head = next;
                    }
                    else
                    {
                        previous.next = next;
                    }
                    break;
                }

                //keep track of the previous node
                previous = current;
                current = current.next;
            }

            return head;
        }
      



        public static ListNode ReverseSub(ListNode start, int q)
        {

            ListNode previous = null;
            ListNode current = start;
            int count = 0; 
            while (current != null)
            {
                ListNode next = current.next;
                current.next = previous;

                previous = current;

                current = next;

                count++;
                //when the previous value is the target node
                if ( count == q)
                {
                    //assign the start.next to the current 
                    //since the target has been reached
                    start.next = current;
                    break;
                }
                
            }

            return previous;
        }

    }
}
