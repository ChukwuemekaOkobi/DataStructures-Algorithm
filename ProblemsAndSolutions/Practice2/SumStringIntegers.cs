using System.Text;

namespace ProblemsAndSolutions.Microsoft
{
    ///<summary>
    ///</summary>
    public class SumStringIntegers
    {

        public static string Sum (string str1, string str2)
        {

            StringBuilder builder = new();

            int carry = 0; 

            int i = str1.Length - 1, j = str2.Length - 1; 

            while(i >= 0 || j >= 0)
            {
                int num1 = i >= 0 ? str1[i] - '0' : 0;
                int num2 = j >= 0 ? str2[j] - '0' : 0;

                int sum = carry + num1 + num2;

                int value = sum % 10;
                carry = sum / 10;

                builder.Insert(0,value);

                i--;
                j--;

            }

            if(carry == 1)
            {
                builder.Insert(0, carry);
            }

            return builder.ToString();

        }
    }


}


