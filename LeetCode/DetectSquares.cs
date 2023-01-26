using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class DetectSquares
    {
        List<Point> points;
        public DetectSquares()
        {
            points = new List<Point>();
        }

        public void Add(int[] point)
        {
            points.Add(new Point(point[0], point[1]));
        }

        public int Count(int[] point)
        {
            Point target = new Point(point[0], point[1]);
            Dictionary<double, List<Point>> distantDict = new Dictionary<double, List<Point>>(); 
            // case 1
            foreach (var p in points)
            {
                var d = GetDistance(target, p);
                if (!distantDict.ContainsKey(d))
                {
                    distantDict.Add(d, new List<Point>(new Point[] { p }));
                }
                else
                {
                    distantDict[d].Add(p);
                }
            }
            int count = 0;
            foreach (var item in distantDict)
            {
                if (item.Value.Count >= 2)
                {
                    var r = Math.Sqrt(2) * item.Key;
                    if (distantDict.ContainsKey(r))
                    {
                        for (int i = 0; i < distantDict[r].Count; i++)
                        {
                            count += CountSquare(target, distantDict[r][i], item.Value);
                        }
                    }

                }
            }

            return count;
        }

        private int CountSquare(Point target, Point point, List<Point> pointList)
        {
            int count = 0;
            int tmpCount1, tmpCount2;
            if (point.x < target.x && point.y < target.y)
            {
                tmpCount1 = pointList.Where(p => p.x == point.x && p.y == target.y).Count();
                tmpCount2 = pointList.Where(p => p.x == target.x && p.y == point.y).Count();

                return tmpCount1 * tmpCount2;

            }

            if (point.x < target.x && point.y > target.y)
            {
                tmpCount1 = pointList.Where(p => p.x == point.x && p.y == target.y).Count();
                tmpCount2 = pointList.Where(p => p.x == target.x && p.y == point.y).Count();

                return tmpCount1 * tmpCount2;
            }

            if (point.x > target.x && point.y > target.y)
            {
                tmpCount1 = pointList.Where(p => p.x == target.x && p.y == point.y).Count();
                tmpCount2 = pointList.Where(p => p.x == point.x && p.y == target.y).Count();

                return tmpCount1 * tmpCount2;
            }

            if (point.x > target.x && point.y < target.y)
            {
                tmpCount1 = pointList.Where(p => p.x == point.x && p.y == target.y).Count();
                tmpCount2 = pointList.Where(p => p.x == target.x && p.y == point.y).Count();

                return tmpCount1 * tmpCount2;
            }


            return count;
        }

        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p2.x - p1.x), 2) + Math.Pow((p2.y - p1.y), 2));
        }

        class Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
