namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// Given a string, what is the minimum number of adjacent swaps required to convert a string into a palindrome. If not possible, return -1.
    /// </summary>
    public class MinSwapPalindrome
    {
        public static bool IsValid(string s)
        {
            int[] counter = new int[26];
            int oddCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                counter[s[i] - 'a']++;
            }
            foreach (int value in counter)
            {
                if (value % 2 != 0)
                {
                    oddCount++;
                }
            }
            return oddCount <= 1;
        }

       private static void  swap(char[] arr, int i, int j)
        {
            var t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }

        public static int MinSwaps(string inp)
        {
            if (!IsValid(inp))
            {
                return -1;
            }

            int n = inp.Length;
            var s = inp.ToCharArray();
            int count = 0;
            for (int i = 0; i < n / 2; i++)
            {
                int left = i;
                int right = n - left - 1;
                while (left < right)
                {
                    if (s[left] == s[right])
                    {
                        break;
                    }
                    else
                    {
                        right--;
                    }
                }
                if (left == right)
                {
                    // s[left] is the character in the middle of the palindrome
                
                    swap(s, left, left + 1);

                    count++;
                    i--;
                }
                else
                {
                    for (int j = right; j < n - left - 1; j++)
                    {
                      
                        swap(s, j, j + 1);
                        count++;
                    }
                }
            }
            return count;
        }
    }
}

