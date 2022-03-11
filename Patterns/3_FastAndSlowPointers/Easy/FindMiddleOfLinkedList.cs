﻿namespace Patterns._3_FastAndSlowPointers
{
    /// <summary>
    /// 
    /**
        * Given the head of a Singly LinkedList, write a method to return the middle node of the LinkedList.

    If the total number of nodes in the LinkedList is even, return the second middle node.

    Example 1:

    Input: 1 -> 2 -> 3 -> 4 -> 5 -> null
    Output: 3
    Example 2:

    Input: 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> null
    Output: 4
    Example 3:

    Input: 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> null
    Output: 4
    */
    /// </summary>

    public class FindMiddleOfLinkedList
    {
        public static ListNode Find (ListNode head)
        {
            var fast = head;
            var slow = head;

            while (fast != null  && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next; 
            }

            return slow; 
        }
    }
}
