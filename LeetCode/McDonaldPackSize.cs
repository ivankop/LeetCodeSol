using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class McDonaldBuyCheck
    {
        public static int[] _packSizes = new int[] { 6, 9, 20 };
        public bool canBuy(int numberOfNuggets, out int[] buyablePack)
        {
            buyablePack = null;
            //return false if number of nuggets smaller than any packs
            if (_packSizes.All(n => numberOfNuggets < n))
            {
                return false;
            }

            //find minimum packs with dynamic programing
            int max = numberOfNuggets + 1;
            int[] dp = new int[numberOfNuggets + 1];
            var prevPack = new int[numberOfNuggets + 1];
            dp = dp.Select(i => max).ToArray();
            dp[0] = 0;
            for (int i = 1; i <= numberOfNuggets; i++)
            {
                for (int j = 0; j < _packSizes.Length; j++)
                {
                    if (_packSizes[j] <= i && dp[i - _packSizes[j]] + 1 < dp[i])
                    {
                        // store the inlcude packs so we can backtracking it later
                        dp[i] = Math.Min(dp[i], dp[i - _packSizes[j]] + 1);
                        prevPack[i] = _packSizes[j];
                    }
                }
            }

            // cannot find the solution
            if (dp[numberOfNuggets] > numberOfNuggets)
            {
                return false;
            }

            // backtrakcing and get the most optimizied combination of packs
            buyablePack = new int[dp[numberOfNuggets]];
            int k = numberOfNuggets;
            int l = 0;
            while (k > 0)
            {
                buyablePack[l++]= prevPack[k];
                k = k - prevPack[k];
            }
            return true;
        }
    }
}
