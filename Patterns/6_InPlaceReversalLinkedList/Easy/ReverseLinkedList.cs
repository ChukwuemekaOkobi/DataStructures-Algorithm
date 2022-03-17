using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._6_InPlaceReversalLinkedList
{
    public class ReverseLinkedList
    {
        public static ListNode Reverse(ListNode head)
        {
            ListNode previous = null; 

            while(head != null)
            {
                ListNode next = head.next;

                head.next = previous;

                previous = head;

                head = next; 
            }

            return previous; 
        }
    }

    public class ListNode
    {
        public  int value = 0;
        public ListNode next;

        public ListNode(int value)
        {
            this.value = value;
        }
    }
}
