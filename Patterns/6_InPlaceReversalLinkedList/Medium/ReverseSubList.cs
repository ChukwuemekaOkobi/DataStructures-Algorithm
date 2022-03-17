namespace Patterns._6_InPlaceReversalLinkedList
{
    /// <summary>
    /// Given a singely linked list reserve are portion of the list from p to q 
    /// 
    /// list: [ 1, 2, 3, 4, 5]  p = 2 and q = 5; 
    /// 
    /// output: [1, 5,4,3,2] 
    ///
    /// </summary>
    public class ReverseSubList
    {
        public static ListNode Reverse(ListNode head, int p, int q)
        {

            ListNode previous = null;
            ListNode current = head;

            //loop through the list and keep track of the previous node
            while (current != null)
            {

                if (current.value == p)
                {
                    //reverse from the required node
                    ListNode next = ReverseSub(current, q);

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

            while (current != null)
            {
                ListNode next = current.next;
                current.next = previous;

                previous = current;

                current = next;

                //when the previous value is the target node
                if (previous.value == q)
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
