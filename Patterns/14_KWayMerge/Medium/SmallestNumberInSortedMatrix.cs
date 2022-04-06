using System;
using System.Collections.Generic;

namespace Patterns._14_KWayMerge
{
    /// <summary>
    /// Kth Smallest Number in sorted matrix
    /// </summary>
    public class SmallestNumberInSortedMatrix
    {
        public static int KWay(int[][] matrix, int k)
        {
            PriorityQueue<Node, int> queue = new();

            for (int i = 0; i < matrix.Length; i++)
            {
                queue.Enqueue(new Node(0, i), matrix[i][0]);
            }


            while (!queue.IsEmpty())
            {
                var node = queue.Dequeue();

                if (node.elementIndex < matrix[node.arrayIndex].Length)
                {
                    var newNode = new Node(node.elementIndex + 1, node.arrayIndex);

                    queue.Enqueue(newNode, matrix[node.arrayIndex][newNode.elementIndex]);
                }

                k--;
                if (k == 0)
                {
                    return matrix[node.arrayIndex][node.elementIndex];
                }
            }

            return -1;
        }

        public static int FindBinarySearch(int[][] matrix, int k)
        {
            int n = matrix.Length;
            int start = matrix[0][0], end = matrix[n - 1][n - 1];
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                // first number is the smallest and the second number is the largest
                int[] smallLargePair = { matrix[0][0], matrix[n - 1][n - 1] };

                int count = CountLessEqual(matrix, mid, smallLargePair);

                if (count == k)
                    return smallLargePair[0];

                if (count < k)
                    start = smallLargePair[1]; // search higher
                else
                    end = smallLargePair[0]; // search lower
            }

            return start;
        }

        private static int CountLessEqual(int[][] matrix, int mid, int[] smallLargePair)
        {
            int count = 0;
            int n = matrix.Length, row = n - 1, col = 0;
            while (row >= 0 && col < n)
            {
                if (matrix[row][col] > mid)
                {
                    // as matrix[row][col] is bigger than the mid, let's keep track of the
                    // smallest number greater than the mid
                    smallLargePair[1] = Math.Min(smallLargePair[1], matrix[row][col]);
                    row--;
                }
                else
                {
                    // as matrix[row][col] is less than or equal to the mid, let's keep track of the
                    // biggest number less than or equal to the mid
                    smallLargePair[0] = Math.Max(smallLargePair[0], matrix[row][col]);
                    count += row + 1;
                    col++;
                }
            }
            return count;
        }

    }
}
