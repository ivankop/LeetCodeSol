using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class CoinChangeSol
    {
        public int CoinChange1(int[] coins, int amount)
        {
            int max = amount + 1;
            int[] dp = new int[amount + 1];
            dp = dp.Select(i => max).ToArray();
            // Arrays.fill(dp, max);
            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }

        public int CoinChange(int[] coins, int amount)
        {
            int max = amount + 1;
            int[] dp = new int[amount + 1];
            var res = new int[amount + 1];
            dp = dp.Select(i => max).ToArray();
            // Arrays.fill(dp, max);
            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i && dp[i - coins[j]] + 1 < dp[i])
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                        res[i] = coins[j];
                    }
                }
            }
            List<int> usedCoins = new List<int>();
            int k = amount;
            while (k > 0)
            {
                usedCoins.Add(res[k]);
                k = k - res[k];
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }

        public int[] CoinChange3(int[] denom, int changeAmount)
        {
            int n = denom.Length;
            int[] count = new int[changeAmount + 1];
            int[] from = new int[changeAmount + 1];

            count[0] = 1;
            for (int i = 0; i < changeAmount; i++)
                if (count[i] > 0)
                    for (int j = 0; j < n; j++)
                    {
                        int p = i + denom[j];
                        if (p <= changeAmount)
                        {
                            if (count[p] == 0 || count[p] > count[i] + 1)
                            {
                                count[p] = count[i] + 1;
                                from[p] = j;
                            }
                        }
                    }

            // No solutions:
            if (count[changeAmount] == 0)
                return null;

            // Build answer.
            int[] result = new int[count[changeAmount] - 1];
            int k = changeAmount;
            while (k > 0)
            {
                result[count[k] - 2] = denom[from[k]];
                k = k - denom[from[k]];
            }

            return result;
        }
    }
}
