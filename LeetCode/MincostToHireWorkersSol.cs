using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MincostToHireWorkersSol
    {
        public double MincostToHireWorkers2(int[] quality, int[] wage, int k)
        {
            double ans = int.MaxValue;
            for (int i = 0; i < quality.Length; i++)
            {
                double capRatio = (double)wage[i] / (double) quality[i];
                PriorityQueue<double, double> acceptedOffer = new PriorityQueue<double, double>();
                for (int j = 0; j < quality.Length; j++)
                {
                    var offer = capRatio * quality[j];
                    if (offer >= wage[j])
                    {
                        acceptedOffer.Enqueue(offer, offer);
                    }
                    
                }
                if (acceptedOffer.Count < k)
                {
                    continue;
                }

                double totalWage = 0;
                int count = 0;
                while (count < k)
                {
                    var offer = acceptedOffer.Dequeue();
                    totalWage += offer;
                    count++;
                }
                ans = Math.Min(ans, totalWage);
            }
            return ans;
        }

        public double MincostToHireWorkers(int[] quality, int[] wage, int k)
        {
            double ans = int.MaxValue;
            List<Tuple<int,int>> sorted = new List<Tuple<int, int>>();
            for (int i = 0; i < quality.Length; i++)
            {
                sorted.Add(new Tuple<int, int>(quality[i], i));
            }
            sorted = sorted.OrderBy( x => x.Item1).ToList();

            for (int i = 0; i < quality.Length; i++)
            {
                double capRatio = (double)wage[i] / (double)quality[i];
                double totalWage = wage[i];
                int count = 1;

                for (int j = 0; j < sorted.Count && count < k; j++)
                {
                    if (sorted[j].Item2 != i )
                    {
                        var offer = capRatio * sorted[j].Item1;
                        if (offer >= wage[sorted[j].Item2])
                        {
                            totalWage += offer;
                            count++;
                        }
                    }
                }
                if (count == k)
                {
                    ans = Math.Min(ans, totalWage);
                }
               
            }
            return ans;
        }

        class MaxHeapComparer : IComparer<int>
        {
            public int Compare(int x, int y) => y.CompareTo(x);
        }
    }
}

