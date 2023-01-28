using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Bitwise
{
    public class MakeStringsEqualSol
    {
        public bool MakeStringsEqual(string s, string target)
        {
            var sArr = ConvertToBinaryList(s);
            var targetArr = ConvertToBinaryList(target);
            for (int i = 0; i < s.Length; i++)
            {
                if (sArr[i] != targetArr[i])
                {
                    if (Find(sArr, targetArr, i))
                    {
                        sArr[i] = targetArr[i];
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool Find(List<bool> sourceArr, List<bool> targetArr, int index)
        {
            for (int i = 0; i < sourceArr.Count; i++)
            {
                if (i != index && sourceArr[i] != sourceArr[index] && sourceArr[i] ^ sourceArr[index] == targetArr[i])
                {
                    return true;
                }
            }
            return false;
        }

        List<bool> ConvertToBinaryList(string s)
        {
            List<bool> res = new List<bool>();
            foreach (var c in s)
            {
                if (c == '0')
                {
                    res.Add(false);
                }
                else
                {
                    res.Add(true);
                }
            }
            return res;
        }
    }
}
