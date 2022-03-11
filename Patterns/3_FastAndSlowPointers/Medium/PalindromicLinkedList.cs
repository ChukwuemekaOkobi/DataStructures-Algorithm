namespace Patterns._3_FastAndSlowPointers
{
    /// <summary>
    /// QUESTION Palidromic Linked List
    /// 
    /// Find 
    /// </summary>

    public class PalindromicLinkedList
    {

        public static bool IsPalindrome(ListNode head)
        {
            if (head == null || head.Next == null)
                return true;

            // find middle of the LinkedList
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            ListNode headSecondHalf = reverse(slow); // reverse the second half
            ListNode copyHeadSecondHalf = headSecondHalf; // store the head of reversed part to revert back later

            // compare the first and the second half
            while (head != null && headSecondHalf != null)
            {
                if (head.Value != headSecondHalf.Value)
                {
                    break; // not a palindrome
                }
                head = head.Next;
                headSecondHalf = headSecondHalf.Next;
            }

            reverse(copyHeadSecondHalf); // revert the reverse of the second half
            if (head == null || headSecondHalf == null) // if both halves match
                return true;
            return false;

            static ListNode reverse(ListNode head)
            {
                ListNode prev = null;
                while (head != null)
                {
                    ListNode Next = head.Next;
                    head.Next = prev;
                    prev = head;
                    head = Next;
                }
                return prev;
            }
        }
    }
}