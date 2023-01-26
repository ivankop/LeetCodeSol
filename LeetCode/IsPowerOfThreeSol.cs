using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class IsPowerOfThreeSol
    {
        public bool IsPowerOfThree(int n)
        {
            if (n < 1)
                return false;
            if (n == 1)
                return true;
            int r = n % 3;
            n = n / 3;

            while (n != 1)
            {
                if (r != 0 || n < 3)
                    return false;

                r = n % 3;
                n = n / 3;
            }
            Console.WriteLine(n + " " + r);
            if (r != 0)
                return false;
            return true;
        }
    }
}
