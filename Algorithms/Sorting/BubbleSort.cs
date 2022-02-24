using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    /// <summary>
    /// Loop through the items in the array 
    /// and swap if the item is greater than the next
    /// </summary>
    public class BubbleSort
    {

        public static void Sort(int[] items)
        {
            
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = 1; j < items.Length - i; j++)
                {
                    if (items[j] < items[j - 1])
                    {
                        Swap(ref items[j], ref items[j - 1]);
                    }
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;

        }
    }

    public class BucketSort
    {
        public static void Sort(int[] items, int noOfBuckets)
        {
             int j = 0; 
            foreach(var bucket in CreateBuckets(items,noOfBuckets))
            {
                bucket.Sort(); 

                foreach(var item in bucket)
                {
                    items[j++] = item; 
                }
            }

        }

        private static List<List<int>> CreateBuckets(int[] items, int noOfBuckets)
        {
            var buckets = new List<List<int>>();

            for (int i = 0; i < noOfBuckets; i++)
            {
                buckets.Add(new List<int>());
            }

            foreach (var item in items)
            {
                buckets[item / noOfBuckets].Add(item);
            }

            return buckets; 
        }
    }
}
