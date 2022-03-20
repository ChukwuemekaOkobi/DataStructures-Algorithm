namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// Rotate 90 degree to right ( Transpose TLR  reflect on rows) or (Transpose BLR reflect on cols)
    /// Rotate -90 or (270) degree to left  ( Transpose LR reflect on cols) or (Transpose BLR reflect on rows)
    /// Rotate 180 degree left of right (Transport TLR and Transpost BLR)

    /// </summary>
    public class MatrixRotation
    {
        
        /// <summary>
        /// Rotate right 90 degrees
        /// Transpose then reflect 
        /// </summary>
        /// <param name="matrix"></param>
        public static void RotateTR(int[][] matrix)
        {
            TransposeTLR(matrix);
            ReflectR(matrix);
       
        }


     
        //from top left to bottom right
        private static void TransposeTLR(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    Swap(matrix, i, j, j, i);
                }
            }
        }

        //from Bottom Left to Top Right
        private static void TransposeBLR(int[][] matrix)
        {
            int n = matrix.Length-1;


            for (int i = n; i >=0 ; i--)
            {
                for (int j = n-i; j <= n; j++)
                {
                    
                    Swap(matrix,n-j, n-i, i, j);
                }
            }
        }

       

        //reflect along column 
        private static void ReflectC(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                int j = 0;
                int k = n - 1;

                while (j < k)
                {
                    Swap(matrix, j++, i, k--, i);
                }
            }
        }

        //reflect along the rows
        private static void ReflectR(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                int j = 0;
                int k = n - 1;

                while (j < k)
                {
                    Swap(matrix, i, j++, i, k--);
                }
            }
        }
    
      
        private static void Swap(int[][] matrix, int r1, int c1, int r2, int c2)
        {
            int temp = matrix[r1][c1];

            matrix[r1][c1] = matrix[r2][c2];

            matrix[r2][c2] = temp;
        }

        public static void RotateLoop(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = matrix[n - 1 - j][i];
                    matrix[n - 1 - j][i] = matrix[n - 1 - i][n - j - 1];
                    matrix[n - 1 - i][n - j - 1] = matrix[j][n - 1 - i];
                    matrix[j][n - 1 - i] = matrix[i][j];
                    matrix[i][j] = temp;
                }
            }
        }

    }




}

