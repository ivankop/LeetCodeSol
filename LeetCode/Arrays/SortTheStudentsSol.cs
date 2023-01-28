using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class SortTheStudentsSol
    {
        public int[][] SortTheStudents(int[][] score, int k)
        {
            List<Tuple<int, int>> kColValues = new List<Tuple<int, int>>();
            for (int i = 0; i < score.Length; i++)
            {
                kColValues.Add(new Tuple<int, int>(score[i][k], i));
            }
            List<int> rowOrder = kColValues.OrderByDescending(x => x.Item1).Select(x => x.Item2).ToList();
            List<int[]> ans = new List<int[]>();
            for (int i = 0; i < rowOrder.Count; i++)
            {
                int row = rowOrder[i];
                int[] arr = new int[score[row].Length];
                for (int j = 0; j < score[row].Length; j++)
                {
                    arr[j] = score[row][j];
                }
                ans.Add(arr);
            }

            return ans.ToArray();
        }
    }
}
