using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    /// QUESTION: 
    /// Given an array, find the average of all subarrays of ‘K’ contiguous elements in it.
    /// Array: [1, 3, 2, 6, -1, 4, 1, 8, 2], K=5
    /// Output: [2.2, 2.8, 2.4, 3.6, 2.8]
    /// </summary>
    public class AverageOfSubArray
    {
        static readonly int[] array = { 1, 3, 2, 6, -1, 4, 1, 8, 2 };

        /// <summary>
        /// Loop through the entire array and for each 5 elements 
        /// calculate the average
        /// Time Complexity: O(n-k * k) == O(n * k)
        /// </summary>
        public static double[] BruteForce(int[] array, int k = 5)
        {
            double[] output = new double[array.Length -(k-1)]; 

            for(int i =0; i<=array.Length -k; i++)
            {
                double sum = 0; 
                for(int j = i; j< i+k; j++)
                {
                    sum += array[j];
                }

                output[i] = sum / k;

                Console.Write(output[i] + " ");
                
            }

            return output;
        }

        /// <summary>
        /// Using the sliding window of size k, reuse the sum of the overlapping slides 
        /// substract the value outside the window and add the value included in the window 
        /// Time Complexity: O(n)
        /// </summary>

        public static double[] SlidingWindow(int[] array, int k = 5)
        {
            double[] output = new double[array.Length - (k - 1)];

           
            double sum = 0;
            int j = 0; //window starting value
     


            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];

                if(i >= k-1)
                {
                    output[j] = sum / k;

                    Console.Write(output[j] + " ");
                    sum -= array[j++];
                }

            }

            return output;
        }
    }
}
