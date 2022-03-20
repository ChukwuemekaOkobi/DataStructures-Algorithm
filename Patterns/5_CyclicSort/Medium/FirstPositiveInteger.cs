using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._5_CyclicSort
{
    public class FirstPositiveInteger
    {
     
            /// <summary>
            /// Sorts the Array, then loops through the sorted array
            /// to find the missing number
            /// O(N*LogN) time
            /// O(N) space
            /// </summary>

            public static int FirstMissingPositive(int[] nums)
            {

                Array.Sort(nums);

                int i = 0;

                int count = 1;

                while (i < nums.Length)
                {

                    int value = nums[i];

                    if (value <= 0)
                    {
                        i++;
                    }

                    else
                    {
                       //skip duplicate values
                        while (i + 1 != nums.Length && value == nums[i + 1])
                        {
                            value = nums[i + 1];
                            i++;
                        }
                        if (value != count)
                        {
                            break;
                        }
                        i++;
                        count++;
                    }



                }

                return count;
            }

            /// <summary>
            /// numbers expected in the array should be [1-length]
            /// we swap numbers based on the index in the array to sort the 
            /// and if the value is in the rang i - length
            /// numbers properly
            /// O(n)
            /// </summary>

            public static int FirstMissingPositive2(int[] nums)
            {
                int i = 0;
                int n = nums.Length;



                while (i < n)
                {

                    if (nums[i] > 0 && nums[i] <= n && nums[i] - 1 != i && nums[i] != nums[nums[i] - 1])
                    {
                        Swap(nums, nums[i]-1, i);
                    }
                    else
                    {
                        i++;
                    }

                }

                for (int j = 0; j < n; j++)
                {
                    if (nums[j] != j + 1)
                    {
                        return j + 1;
                    }
                }

                return n + 1;
            }



            private static void Swap(int[] nums, int i, int j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
    }
