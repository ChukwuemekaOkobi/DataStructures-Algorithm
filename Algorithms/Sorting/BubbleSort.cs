using System;
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
}
