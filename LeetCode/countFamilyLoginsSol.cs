using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class countFamilyLoginsSol
    {
        public static int countFamilyLogins(List<string> logins)
        {
            Dictionary<string, int> countFamilyLogins = new Dictionary<string, int>();
            foreach (string log in logins)
            {
                var tmp = rotateRight(log);
                if (!countFamilyLogins.ContainsKey(tmp))
                {
                    countFamilyLogins.Add(tmp, 1);
                }
                else
                {
                    countFamilyLogins[tmp] = countFamilyLogins[tmp] + 1;
                }
            }
            int count = 0;
            foreach (string log in logins)
            {
                if (countFamilyLogins.ContainsKey(log))
                {
                    count += countFamilyLogins[log];
                }
            }
            return count;
        }

        private static string rotateRight(string input)
        {
            char[] output = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'z')
                {
                    output[i] = 'a';
                }
                else
                {
                    output[i] = (char)(input[i] + 1);
                }
            }

            return new string(output);
        }

    }
}
