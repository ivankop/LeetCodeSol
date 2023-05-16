using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class MinPathCostSol
    {
        public int MinPathCost(int[][] grid, int[][] moveCost)
        {
            int[][] minCost = new int[grid.Length][];

            // PriorityQueue<Tuple<int,int,int>, int > queue = new PriorityQueue<Tuple<int, int, int>, int>();
            /*
            minCost[1] = new int[grid[0].Length];
            for (int i = 0; i < grid[0].Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    var cost = grid[0][i] + moveCost[grid[0][i]][j] + grid[1][j];
                    if (minCost[1][j] == 0)
                        minCost[1][j] = cost;
                    else
                        minCost[1][j] = Math.Min(cost, minCost[1][j]);
                    queue.Enqueue(new Tuple<int, int, int>(grid[1][j], cost, 1), cost);
                }
                `we`poipoipoi~pwoeirpweoriwpeO
            }queue.Enqueue(new Tup
            */
            minCost[0] = new int[grid[0].Length];
            for (int j = 0; j < grid[0].Length; j++)
            {
                minCost[0][j] = grid[0][j];
            }
            for (int i = 0; i < grid.Length - 1; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)                    
                {
                    for (int k = 0; k < grid[i].Length; k++)
                    {
                        var cost = minCost[i][j] + moveCost[grid[i][j]][k] + grid[i + 1][k];
                        if (minCost[i + 1][k] == 0)
                            minCost[i + 1][k] = cost;
                        else
                            minCost[i + 1][k] = Math.Min(cost, minCost[i + 1][k]);
                    }
                }
            }

            var ans = minCost[grid.Length - 1].Min();
            return ans;

            /*
            while (queue.Count > 0)
            {
                int count = queue.Count;
                PriorityQueue<Tuple<int, int, int>, int> nextQueue = new PriorityQueue<Tuple<int, int, int>, int>();
                for (int i = 0; i < count; i++)
                {
                    var cell = queue.Dequeue();
                    //queue.Clear();
                    var cost = cell.Item2;
                    if (cell.Item3 == grid.Length - 1)
                    {
                        return cost;
                    }
                    int row = cell.Item3 + 1;
                    Console.WriteLine($"{row}");
                    for (int j = 0; j < grid[0].Length; j++)
                    {
                        var newCost = cost + moveCost[cell.Item1][j] + grid[row][j];
                        Console.Write($" {newCost} ");
                        nextQueue.Enqueue(new Tuple<int, int, int>(grid[row][j], newCost, row), newCost);
                    }
                    Console.WriteLine($"-----------------");
                }
                
            }
            return 0;
            */
        }
    }
}

