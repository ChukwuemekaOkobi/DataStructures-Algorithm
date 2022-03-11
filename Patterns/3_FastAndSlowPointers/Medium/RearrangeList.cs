namespace Patterns._3_FastAndSlowPointers
{
    /// <summary>
    /// QUESTION: Rearrange a LinkedList (medium)#
    ///Given the head of a Singly LinkedList, write a method to modify the LinkedList 
    ///such that the nodes from the second half of the LinkedList are inserted alternately 
    ///to the nodes from the first half in reverse order.So if the LinkedList has 
    ///nodes 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> null, your method should return 1 -> 6 -> 2 -> 5 -> 3 -> 4 -> null.
    /// Your algorithm should not use any extra space and the input LinkedList should be modified in-place.
    /// </summary>

    public class RearrangeList
    {

        public static void Reorder(ListNode head)
        {
            if (head == null || head.Next == null)
                return;

            // find the middle of the LinkedList
            ListNode slow = head, fast = head;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            // slow is now pointing to the middle node
            ListNode headSecondHalf = Reverse(slow); // reverse the second half
            ListNode headFirstHalf = head;

            // rearrange to produce the LinkedList in the required order
            while (headFirstHalf != null && headSecondHalf != null)
            {
                ListNode temp = headFirstHalf.Next;
                headFirstHalf.Next = headSecondHalf;
                headFirstHalf = temp;

                temp = headSecondHalf.Next;
                headSecondHalf.Next = headFirstHalf;
                headSecondHalf = temp;
            }

            // set the Next of the last node to 'null'
            if (headFirstHalf != null)
                headFirstHalf.Next = null;
        }

        private static ListNode Reverse(ListNode head)
        {
            ListNode prev = null; 

            while(head != null)
            {
                ListNode Next = head.Next; // assign the next value in the list to hold ref to all others 

                head.Next = prev; //disconnect the head and assign it next value to previous; 

                prev = head; //move the previous to the head position 

                head = Next; // finally assign the Next node to the head. s
            }
            return prev;
        }
    }
}