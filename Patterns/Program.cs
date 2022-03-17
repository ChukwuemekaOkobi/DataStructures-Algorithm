using Patterns._6_InPlaceReversalLinkedList;
using System;
using System.Collections.Generic;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
            head.next.next.next.next.next.next = new ListNode(7);
            head.next.next.next.next.next.next.next = new ListNode(8); 
            
            ListNode result = ReverseEveryAlternateKSub.ReverseAlternate(head, 3);

            while(result != null)
            {
                Console.Write(result.value  + " ");
                result = result.next; 
            }
        }

    }

}
