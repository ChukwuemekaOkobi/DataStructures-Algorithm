using DataStructures;
using DataStructures.LinkedList;
using DataStructures.Stacks;
using System.Collections.Generic;
using System.Text;
using System;
using DataStructures.Queues;
using DataStructures.HashTable;
using System.Linq;
using System.Diagnostics;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] nums = { 2,11,78,7};

            Console.WriteLine(isPL(121));

        }

        static bool isPL(int x)
        {
            if(x < 0)
            {
                return false;
            }

            string num = x.ToString();

            int j = num.Length - 1;

            for(int i = 0; i< num.Length; i++)
            {
                if(!(num[i] == num[j--]))
                {
                    return false;
                }
            }

            return true;
        }

       

      
    }
}
