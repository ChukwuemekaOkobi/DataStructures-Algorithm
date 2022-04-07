using System.Collections.Generic;

namespace Patterns._13_TopKElements
{
    /// <summary>
    /// Given an array of points in a 2D
    // plane, find ‘K’ closest points to the origin.

    //Example 1:

    //Input: points = [[1,2],[1,3]], K = 1
    //Output: [[1,2]]
    //Explanation: The Euclidean distance between(1, 2) and the origin is sqrt(5).
    //The Euclidean distance between(1, 3) and the origin is sqrt(10).
    //Since sqrt(5) < sqrt(10), therefore(1, 2) is closer to the origin.
    //Example 2:

    //Input: point = [[1, 3], [3, 4], [2, -1]], K = 2
    //Output: [[1, 3], [2, -1]]
    /// </summary>
    public class KClosestPointToOrigin
    {
        // same and k smallest dstance to origin
        public static List<Point> ClosestPoint(Point[] points, int k)
        {
            var list = new List<Point>();

            var queue = new PriorityQueue<Point, int>(new MyComparer());

            for(int i = 0; i< points.Length; i++)
            {
                if(queue.Count < k)
                {
                    queue.Enqueue(points[i], points[i].DistFromOrigin());
                }
                else
                {
                    if(queue.Peek().DistFromOrigin() > points[i].DistFromOrigin())
                    {
                        queue.Dequeue();
                        queue.Enqueue(points[i], points[i].DistFromOrigin());
                    }
                }
            }

            while (!queue.IsEmpty())
            {
                list.Add(queue.Dequeue());
            }

            return list;
        }

    }
    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int DistFromOrigin()
        {
            // ignoring sqrt
            return (x * x) + (y * y);
        }
    }

}
