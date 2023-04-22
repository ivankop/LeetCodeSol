using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DP
{
    public class MaximumProfitSol
    {
        static long maxProfit = long.MinValue;
        static Dictionary<Tuple<int, int, long, long>, long> mem;
        public long maximumProfit1(List<int> price)
        {
            maxProfit = long.MinValue;
            mem = new Dictionary<Tuple<int, int, long, long>, long>();
            FindMaximumProfitRec(price, 0, 0, 0, 0);
            return maxProfit;
        }

        public long maximumProfit(List<int> price)
        {
            var r2l = buildR2L(price);
            maxProfit = 0;
            for (int i = 0; i < price.Count; i++)
            {
                if (price[i] < r2l[i])
                {
                    maxProfit += r2l[i] - price[i];
                }
            }

            return maxProfit;
        }

        int[] buildR2L(List<int> price)
        {
            int[] output = new int[price.Count];
            for (int i = price.Count - 1; i >= 0; i--)
            {
                if (i == price.Count - 1)
                {
                    output[i] = price[i];
                }
                else
                {
                    output[i] = Math.Max(output[i + 1], price[i]);
                }
            }
            return output;
        }
        public static long FindMaximumProfitRec(List<int> price, int min, int share, long cost, long profit)
        {
            if (min == price.Count)
            {
                maxProfit = Math.Max(maxProfit, profit);
                return profit;
            }
            Tuple<int, int, long, long> pair = new Tuple<int, int, long, long>(min, share, cost, profit);
            if (mem.ContainsKey(pair))
            {
                return mem[pair];
            }
            // buy
            // increase share, cost, profit is not changed 
            long p1 = FindMaximumProfitRec(price, min + 1, share + 1, cost + price[min], profit);

            //sell all share at current price
            var newProfit = profit + share * price[min] - cost;
            long p2 = long.MinValue;
            if (newProfit > 0)
            {
                p2 = FindMaximumProfitRec(price, min + 1, 0, 0, newProfit);
            }

            //do nothing
            long p3 = FindMaximumProfitRec(price, min + 1, share, cost, profit);

            long bestProfit = Math.Max(Math.Max(p1, p2), p3);
            mem[pair] = bestProfit;
            return bestProfit;
        }

    }
}
