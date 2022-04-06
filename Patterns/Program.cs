
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Patterns._14_KWayMerge;


namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(2);
            l1.Next = new ListNode(6);
            l1.Next.Next = new ListNode(8);

            ListNode l2 = new ListNode(3);
            l2.Next = new ListNode(6);
            l2.Next.Next = new ListNode(7);

            ListNode l3 = new ListNode(1);
            l3.Next = new ListNode(3);
            l3.Next.Next = new ListNode(4);


            Console.WriteLine(KthSmallestNumber.Find(new ListNode[] { l1, l2, l3 }, 5));

            List<int[]> list = new List<int[]>()
            {
                new int[] { 2, 6, 8 },
                new int[] {3,5,7,9},
                new int[] {1,3,3,4}
            };

            Console.WriteLine(KthSmallestNumber.Find(list,5));

        }

    }

}
