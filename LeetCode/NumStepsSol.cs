using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class NumStepsSol
    {
        public int NumSteps(string s)
        {
            var binNumber = ConvertToBinaryList(s);
            int step = 0;

            Reduce(binNumber, ref step);
            
            return step;
        }

        List<bool> ConvertToBinaryList(string s)
        {
            List<bool> res = new List<bool>();
            foreach (var c in s)
            {
                if (c == '0')
                {
                    res.Add(false);
                } else
                {
                    res.Add(true);
                }
            }
            return res;
        }

        private List<bool> Reduce(List<bool> binNumber, ref int step)
        {
            if (binNumber.Count == 1 && binNumber[0] == true) // == 1
            {
                return binNumber;
            }
            step++;
            if (binNumber[binNumber.Count - 1] == false) // even
            {
                return Reduce(RightShift(binNumber), ref step);
            }
            else
            {
                return Reduce(IncreaseByOne(binNumber), ref step);
            }
        }

        List<bool> RightShift(List<bool> binNumber)
        {
            binNumber.RemoveAt(binNumber.Count - 1);
            // binNumber.Insert(0, false);
            return binNumber;
        }

        List<bool> IncreaseByOne(List<bool> binNumber)
        {
            int i = binNumber.Count - 1;
            while (i >= 0 && binNumber[i])
            {
                binNumber[i] = false;
                i--;
            }
            if (i < 0)
                binNumber.Insert(0, true);
            else
                binNumber[i] = true;

            return binNumber;
        }
    }
}
