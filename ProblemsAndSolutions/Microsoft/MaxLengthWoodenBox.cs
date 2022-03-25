namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// There are two wooden stics of lengths A and B respectively.
    /// create 4 sticks of equal length to create a square box 
    /// return the max length of the box 
    /// Examples :
    //    a.Given A = 10, B = 21, the function should return 7. We can split the second stick into three sticks of length 7 and shorten the first stick by 3.
    //b.Given A = 13, B = 11, the function should return 5. We can cut two sticks of length 5 from each of the given sticks.
    // c.Given A = 2, B = 1, the function should return 0. it is not possible to make any square from the give sticks.
    //d.Give A = 1, B = 8, the function should return 2. We can cut stick B into four parts.

    /// </summary>
    public class MaxLengthWoodenBox
    {
        public static  int Square(int A, int B)
        {
            int result;
            if (A < 4 && B < 4 && A + B >= 4)
            {
                result = 1;
                return result;
            }
            int maxCutForA = A / 4;
            int maxCutForB = B / 4;

            result = maxCutForA + maxCutForB;
            
            return result;
        }

        public static int FindLength(int a, int b)
        {
            int maxLength = (a + b) / 4;   // Our solution will live between 0 and this max length only
           
            while (maxLength > 0)
            {
                if (a / maxLength + b / maxLength == 4) // If we get total 4 sticks out of 2 large sticks then we will get solution
                    return maxLength;
                --maxLength;
            }
            return 0;
        }
   
    
    }
}

