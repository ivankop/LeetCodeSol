using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class RomanToInterger
    {
        public int RomanToInt(string s)
        {
            // M CM XC IV
            // 
            Dictionary<string, int> map = new Dictionary<string, int>();
            map.Add("I", 1);
            map.Add("V", 5);
            map.Add("X", 10);
            map.Add("L", 50);
            map.Add("C", 100);
            map.Add("D", 500);
            map.Add("M", 1000);
            Dictionary<string, int> submap = new Dictionary<string, int>();
            submap.Add("IV", 4);
            submap.Add("VI", 6);
            submap.Add("VII", 7);
            submap.Add("VIII", 8);
            submap.Add("IX", 9);
            submap.Add("XI", 11);
            submap.Add("XII", 12);
            submap.Add("XIII", 13);
            submap.Add("XL", 40);
            submap.Add("LX", 60);
            submap.Add("LXX", 70);
            submap.Add("LXXX", 80);
            submap.Add("XC", 90);
            submap.Add("CX", 110);
            submap.Add("CXX", 120);
            submap.Add("CXXX", 130);
            submap.Add("CD", 400);
            submap.Add("DC", 600);
            submap.Add("DCC", 700);
            submap.Add("DCCC", 800);
            submap.Add("CM", 900);
            submap.Add("MC", 1100);
            submap.Add("MCC", 1200);
            submap.Add("MCCC", 1300);

            List<int> list = new List<int>();
            while (s.Length > 0)
            {
                var match = false;
                foreach (var sub in submap.Keys.OrderByDescending( k => k).ToList())
                {
                    if (s.EndsWith(sub))
                    {
                        list.Add(submap[sub]);
                        s = s.Substring(0, s.Length - sub.Length);
                        match = true;
                        break;
                    }
                }

                if (!match)
                {
                    foreach (var sub in map)
                    {
                        if (s.EndsWith(sub.Key))
                        {
                            list.Add(sub.Value);
                            s = s.Substring(0, s.Length - sub.Key.Length);
                            break;
                        }
                    }
                }
            }
            var ans = list.Sum();
            return ans;
        }
    }
}
