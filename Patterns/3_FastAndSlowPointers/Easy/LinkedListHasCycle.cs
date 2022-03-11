using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._3_FastAndSlowPointers
{

    public class ListNode
    {
        public int Value = 0;
        public ListNode Next;

        public ListNode(int value)
        {
            this.Value = value;
        }
    }


    /// <summary>
    /// Given the head of a Singly LinkedList, write a function to determine if the LinkedList has a cycle in it or not.
    /// </summary>
    public class LinkedListHasCycle
    {

        public static bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.Next != null)
            {
                if(slow == fast)
                {
                    return true; 
                }
                fast = fast.Next.Next;
                slow = slow.Next;
       
            }
            return false;
        }

        /// <summary>
        /// Given the head of a LinkedList with a cycle, find the length of the cycle
        /// </summary>

        public static int LengthOfCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (slow == fast) // found the cycle
                    return CalculateLength(slow);
            }
            return 0;

            static int CalculateLength(ListNode slow)
            {
                ListNode current = slow;
                int cycleLength = 0;
                do
                {
                    current = current.Next;
                    cycleLength++;
                } while (current != slow);
                return cycleLength;
            }
        }


        public static ListNode FindStart(ListNode head, int cycleLength)
        {
            ListNode pointer1 = head, pointer2 = head;
            // move pointer2 ahead 'cycleLength' nodes
            while (cycleLength > 0)
            {
                pointer2 = pointer2.Next;
                cycleLength--;
            }

            // increment both pointers until they meet at the start of the cycle
            while (pointer1 != pointer2)
            {
                pointer1 = pointer1.Next;
                pointer2 = pointer2.Next;
            }

            return pointer1;
        }


    }



}
