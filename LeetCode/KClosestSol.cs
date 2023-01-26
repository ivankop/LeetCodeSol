namespace LeetCode
{
    public class KClosestSol
    {
        public int[][] KClosest1(int[][] points, int k)
        {
            List<Point> pointList = new List<Point>();
            for (int i = 0; i < points.GetLength(0); i++)
            {
                pointList.Add(new Point(points[i][0], points[i][1]));
            }

            var res = pointList.OrderBy(p => p.Distance).Take(k).ToList();
            var resArr = new int[res.Count][];
            for (int i = 0; i < res.Count; i++)
            {
                resArr[i] = new int[2];
                resArr[i][0] = res[i].X;
                resArr[i][1] = res[i].Y;
            }
            return resArr;
        }

        public int[][] KClosest(int[][] points, int k)
        {
            PriorityQueue<Point, double> priorityQueue = new PriorityQueue<Point, double>();
            for (int i = 0; i < points.GetLength(0); i++)
            {
                var p = new Point(points[i][0], points[i][1]);
                priorityQueue.Enqueue(p, p.Distance);
            }

            var resArr = new int[k][];
            for (int i = 0; i < k; i++)
            {
                var p = priorityQueue.Dequeue();
                resArr[i] = new int[2];
                resArr[i][0] = p.X;
                resArr[i][1] = p.Y;
            }
            return resArr;
        }

        class Point
        {
            public int X;
            public int Y;
            public double Distance;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
                Distance = Math.Sqrt(x * x + y * y);
            }
        }
    }
}
