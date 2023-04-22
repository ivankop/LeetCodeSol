using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ZigzagConversion
    {
        List<List<char>> output;
        public string Convert(string s, int numRows)
        {
            output = new List<List<char>>();
            for (int i = 0; i < numRows; i++)
            {
                output.Add(new List<char>());
            }
            ConvertRec(s, 0, numRows, 0, true);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < output.Count; i++)
            {
                sb.Append(new string(output[i].ToArray()));
            }
            return sb.ToString();
        }

        void ConvertRec(string s, int index, int numRows, int row, bool isDown)
        {
            if (index == s.Length)
            {
                return;
            }
            if (row == numRows - 1)
            {
                isDown = false;
            } 
            else if (row == 0)
            {
                isDown = true;
            }
            // output[row].Add(s[index]);
            if (isDown)
            {
                row++;
            }
            else
            {
                row--;
            }
            ConvertRec(s, index + 1, numRows, row, isDown);
        }
    }
}
