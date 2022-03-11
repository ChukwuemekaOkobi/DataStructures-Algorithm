using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._3_FastAndSlowPointers
{
    /// <summary>
    /// Any number will be called a happy number if, after repeatedly replacing 
    /// it with a number equal to the sum of the square of all of its digits, leads us to number ‘1’.
    /// All other (not-happy) numbers will never reach ‘1’. Instead, 
    /// they will be stuck in a cycle of numbers which does not include ‘1’.
    /// 
    /// Input: 23   
    /// Output: true (23 is a happy number)  
    /// 
    /// Input: 12
    /// Output: false (12 is not happy number)  

    /// </summary>
    public class HappyNumber
    {
        public static bool Find(int num)
        {
            // // TODO: Write your code here

            int sum = num;

            HashSet<int> Sums = new HashSet<int>();


            while (sum != 1 && !Sums.Contains(sum))
            {

                int temp = 0, digit;
                while (sum > 0)
                {
                    digit = sum % 10;
                    temp += digit * digit;
                    sum /= 10;
                }

                sum = temp;

                Sums.Add(sum);

            }

            return sum == 1;
        }

        public static bool Find2(int num)
        {
            int slow = num, fast = num;
            do
            {
                slow = FindSquareSum(slow); // move one step
                fast = FindSquareSum(FindSquareSum(fast)); // move two steps
            } while (slow != fast); // found the cycle

            return slow == 1; // see if the cycle is stuck on the number '1'

            static int FindSquareSum(int num)
            {
                int sum = 0, digit;
                while (num > 0)
                {
                    digit = num % 10;
                    sum += digit * digit;
                    num /= 10;
                }
                return sum;
            }
        }


    }


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