using System.Collections.Generic;

namespace Algorithms.Sorting
{
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
