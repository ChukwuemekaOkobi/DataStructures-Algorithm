using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._6_InPlaceReversalLinkedList
{
    /// <summary>
    ///  Given the head of a Singly LinkedList and a number ‘k’, rotate the LinkedList to the right by ‘k’ nodes.
    /// </summary>


    public class RotateLinkedListByK
    {

        public static ListNode Rotate (ListNode head, int rotations)
        {
            if (head == null || head.next == null || rotations <= 0)
                return head;

            // find the length and the last node of the list
            ListNode lastNode = head;
            int listLength = 1;
            while (lastNode.next != null)
            {
                lastNode = lastNode.next;
                listLength++;
            }

            lastNode.next = head; // connect the last node with the head to make it a circular list
            rotations %= listLength; // no need to do rotations more than the length of the list
            int skipLength = listLength - rotations;
            ListNode lastNodeOfRotatedList = head;
            for (int i = 0; i < skipLength - 1; i++)
                lastNodeOfRotatedList = lastNodeOfRotatedList.next;

            // 'lastNodeOfRotatedList.next' is pointing to the sub-list of 'k' ending nodes
            head = lastNodeOfRotatedList.next;
            lastNodeOfRotatedList.next = null;
            return head;
        }
    }
}
