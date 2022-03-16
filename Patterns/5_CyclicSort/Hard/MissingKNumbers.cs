using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._5_CyclicSort.Hard
{
    public class MissingKNumbers
    {
        public static List<int> FindNumbers(int[] nums, int k)
        {
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] > 0 && nums[i] <= nums.Length && nums[i] != nums[nums[i] - 1])
                    Swap(nums, i, nums[i] - 1);
                else
                    i++;
            }

            //using the hash set to keep track on items in the array
            List<int> missingNumbers = new ();
            ISet<int> extraNumbers = new HashSet<int>();
            for (i = 0; i < nums.Length && missingNumbers.Count < k; i++)
                if (nums[i] != i + 1)
                {
                    missingNumbers.Add(i + 1);
                    extraNumbers.Add(nums[i]);
                }

            // add the remaining missing numbers
            for (i = 1; missingNumbers.Count < k; i++)
            {
                int candidateNumber = i + nums.Length;
                // ignore if the array contains the candidate number
                if (!extraNumbers.Contains(candidateNumber))
                    missingNumbers.Add(candidateNumber);
            }

            return missingNumbers;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
