using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class LongestPalindromic
    {
        public string LongestPalindrome(string s)
        {
            if (s.Length == 1)
            {
                return s;
            }
            //var dict = new Dictionary<string, int>();
            char[] arr = s.ToCharArray();
            int length = arr.Length;
            int max = -1;
            string res = string.Empty;
            for (int i = 0; i < length - 1;i++)
            {
                int r = i + max;
                while (r < length)
                {
                    if (isPalindromesList(arr,i,r))
                    {
                        if (r - i > max)
                        {
                            max = r - i;
                            res = s.Substring(i, r - i + 1);
                        }
                    }
                    r++;
                }
            }

            return res;
        }

        private static bool isPalindromes(string input)
        {
            char[] arr = input.ToCharArray();
            int l = 0;
            int r = arr.Length -1;
            while(l <= r)
            {
                if (arr[l] != arr[r])
                {
                    return false;
                }
                l++;
                r--;
            }

            return true;

            //return input.SequenceEqual(input.Reverse());
        }

        private static bool isPalindromesList(char[] arr, int l, int r)
        {
            while (l <= r)
            {
                if (arr[l] != arr[r])
                {
                    return false;
                }
                l++;
                r--;
            }

            return true;
        }
        private static bool isPalindromes2(string input)
        {
            return input.SequenceEqual(input.Reverse());
        }

        public string LongestPalindrome_bk(string s)
        {
            if (s.Length == 1)
            {
                return s;
            }
            //var dict = new Dictionary<string, int>();
            char[] arr = s.ToCharArray();
            string tmpStr;
            int max = 0;
            string res = string.Empty;
            for (int i = 0; i < s.Length - 1; i++)
            {
                int r = i + max + 1;
                while (r <= s.Length)
                {
                    //if (r - i > max)
                    {
                        tmpStr = s.Substring(i, r - i);
                        if (isPalindromes(tmpStr))
                        {
                            //dict.Add(tmpStr, tmpStr.Length);
                            if (tmpStr.Length > max)
                            {
                                max = tmpStr.Length;
                                res = tmpStr;
                            }
                        }
                    }
                    r++;
                }
            }

            return res;
        }
    }
}
