namespace Algorithms.Sorting
{
    /// <summary>
    /// Find the minimum value in the array 
    /// at each pass and swap with the first index of the unsorted array
    /// </summary>
    public class SelectionSort
    {
        
        public static void Sort(int[] items)
        {
          
            for (int i = 0; i < items.Length - 1; i++)
            {
                var minIndex = i; 
                for (int j = i+1; j < items.Length ; j++)
                {
                    if(items[minIndex] > items[j])
                    {
                        minIndex = j;
                    }  
                }
          
                  Swap(ref items[i], ref items[minIndex]);
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
