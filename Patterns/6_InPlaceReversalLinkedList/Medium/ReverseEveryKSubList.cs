namespace Patterns._6_InPlaceReversalLinkedList
{
    /// <summary>
    /// Given the head of a LinkedList and a number ‘k’, reverse every ‘k’ sized sub-list starting from the head.

    /// If, in the end, you are left with a sub-list with less than ‘k’ elements, reverse it too.
    /// </summary>

    public class ReverseEveryKSubList
    {
        /// <summary>
        ///  Reserve the linked list in group of k (HARD)
        /// </summary>

        public static ListNode ReverseNodeInGroupK(ListNode head, int k)
        {
            var current = head;
            ListNode previous = null;

            while (current != null)
            {

                ListNode next = ReverseKElement.ReverseSub(current, k);

                if (previous == null)
                {  //if previous is still null then p is the head node
                   //assign the new head to the output of reverseSub
                    head = next;
                }
                else
                {
                    previous.next = next;
                }


                //keep track of the previous value
                previous = current;
                current = current.next;

            }

            return head;
        }

    }
}
