using System;
using System.Collections.Generic;
using System.Text;

namespace RottingOranges
{
    public class OCRCompare
    {
        public bool solution(string S, string T)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            // convert input to character list
            var firstOCRList = convertToCharList(S);
            var secondOCRList = convertToCharList(T);
            if (firstOCRList.Count != secondOCRList.Count)
                return false;

            for (int i = 0; i < firstOCRList.Count; i++)
            {
                // compare to list, ignore ? character
                if (firstOCRList[i] != '?' && secondOCRList[i] != '?' && firstOCRList[i] != secondOCRList[i])
                {
                    return false;
                }
            }

            return true;
        }

        private List<char> convertToCharList(string input)
        {
            List<char> ocrList = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                // check if it's a number replacement
                if (Char.IsDigit(input[i]))
                {
                    StringBuilder sb = new StringBuilder();
                    while (i < input.Length && Char.IsDigit(input[i]))
                    {
                        sb.Append(input[i]);
                        i++;
                    }
                    i--;
                    for (int j = 0; j < int.Parse(sb.ToString()); j++)
                    {
                        ocrList.Add('?');
                    }
                }
                else
                {
                    ocrList.Add(input[i]);
                }
                
            }
            
            return ocrList;
        }
    }
}
