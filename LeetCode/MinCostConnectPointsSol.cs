using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinCostConnectPointsSol
    {
        public int MinCostConnectPoints(int[][] points)
        {
            HashSet<Point> visited = new HashSet<Point>();
            PriorityQueue<Tuple<Point, Point>, int> queue = new PriorityQueue<Tuple<Point, Point>, int>();
            int cost = 0;
            var firstPoint = new Point(points[0][0], points[0][1]);
            visited.Add(firstPoint);
            UpdateQueue(points, firstPoint, queue, visited);
            while (visited.Count < points.Length)
            {
                var nextPoint = queue.Dequeue();
                while (visited.Contains(nextPoint.Item2))
                {
                    nextPoint = queue.Dequeue();
                }
                cost += GetDistance(nextPoint.Item1, nextPoint.Item2);
                visited.Add(nextPoint.Item2);
                UpdateQueue(points, nextPoint.Item2, queue, visited);
            }

            return cost;
        }

        private int GetDistance(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
        }

        private void UpdateQueue(int[][] points, Point p, PriorityQueue<Tuple<Point, Point>, int> queue, HashSet<Point> visited)
        {
            for (int i = 0; i < points.Length; i++)
            {
                var nextNode = new Point(points[i][0], points[i][1]);
                if (!visited.Contains(nextNode))
                {
                    var distance = GetDistance(p, nextNode);
                    queue.Enqueue(new Tuple<Point, Point>(p, nextNode), distance);
                }
            }
        }

        class Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object? obj)
            {
                Point p = obj as Point;
                if (p == null)
                    return false;
                return X == p.X && Y == p.Y;
            }

            public override int GetHashCode()
            {
                return X.GetHashCode() + Y.GetHashCode();
            }
        }
    }
}
