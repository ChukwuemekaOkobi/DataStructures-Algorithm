using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Google
{
    public class SquareRoot
    {
        public static long FindBruteForce(int x)
        {
            if( x < 0)
            {
                throw new ArgumentException();
            }

            if(x <= 1)
            {
                return x; 
            }
            BigInteger ans = 0;
            BigInteger min = 0, max = x, mid;

            mid = max / 2;

            for(int i = 1; i<=mid; i++)
            {
                BigInteger item = i * i; 

                if(item > x)
                {
                    return i - 1;
                }
                else if(item == x)
                {
                    return i;
                }
            }

            return (int)mid;

        }

        public static int FindBinarySearch(int x)
        {
            if (x <= 1)
            {
                return x;
            }
            BigInteger ans = 0;
            BigInteger min = 0, max = x, mid;

            while (min <= max)
            {
                mid = (min + max) / 2;
                if (mid * mid == x)
                {
                    ans = mid; break;
                }
                if (mid * mid < x)
                {
                    min = mid + 1; ans = mid;
                }
                else max = mid - 1;
            }
            int num = (int)ans;
            return num;
        }
    }
}
