using System;

namespace ProblemsAndSolutions.Google
{
    public class MaxGold
    {
        public int GetMaximumGold(int[][] grid)
        {

            if (grid == null || grid.Length == 0)
            {
                return 0;
            }
            int m = grid.Length;
            int n = grid[0].Length;

            int Max = 0;

            var visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            for (int row = 0; row < m; row++)
            {

                for (int col = 0; col < n; col++)
                {
                    if (grid[row][col] > 0)
                    {
                        int gold = Find(grid, row, col, visited);

                        Max = Math.Max(Max, gold);
                    }
                }
            }

            return Max;
        }

        private int Find(int[][] grid, int row, int col, bool[][] visited)
        {
            if (row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length)
            {
                return 0;
            }

            if (visited[row][col] || grid[row][col] == 0)
            {
                return 0;
            }
            visited[row][col] = true;

            int left = Find(grid, row, col - 1, visited);
            int right = Find(grid, row, col + 1, visited);
            int up = Find(grid, row - 1, col, visited);
            int down = Find(grid, row + 1, col, visited);

            int max = Math.Max(left, Math.Max(right, Math.Max(up, down)));

            int gold = max + grid[row][col];

            visited[row][col] = false;

            return gold;
        }
    }
}
