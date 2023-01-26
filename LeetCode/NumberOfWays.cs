using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class NumberOfWaysSol
    {
        public long NumberOfWays1(string s)
        {
            long count = 0;
            Dictionary<long, long> mem = new Dictionary<long, long>();
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (i > 0 && s[i] == s[i - 1] && mem.ContainsKey(i - 1))
                {
                    mem[i] = mem[i - 1];
                }
                if (mem.ContainsKey(i))
                {
                    count += mem[i];
                }
                else
                {
                    for (int j = i + 1; j < s.Length - 1; j++)
                    {
                        if (s[j] == s[j - 1] && mem.ContainsKey(j - 1))
                        {
                            mem[j] = mem[j - 1];
                        }
                        if (s[j] != s[i])
                        {
                            if (mem.ContainsKey(j))
                            {
                                count += mem[j];
                                //mem[j] += mem[j];
                            }
                            else
                            {
                                for (int k = j + 1; k < s.Length; k++)
                                {
                                    if (s[k] != s[j])
                                    {
                                        //break;
                                        count++;
                                        if (!mem.ContainsKey(j))
                                        {
                                            mem.Add(j, 0);
                                        }
                                        mem[j]++;
                                        if (!mem.ContainsKey(i))
                                        {
                                            mem.Add(i, 0);
                                        }
                                        mem[i]++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }
        public long NumberOfWays_Stack(string s)
        {
            mem = new Dictionary<Tuple<int, char, int>, int>();
            Tuple<int, char, string> first = new Tuple<int, char, string>(0, '-', "");
            Stack<Tuple<int, char, string>> stack = new Stack<Tuple<int, char,string>>();
            stack.Push(first);
            List<int> stackValue = new List<int>();
            while (stack.Count > 0)
            {
                var currentPos = stack.Pop();
                int index = currentPos.Item1;
                char prevBuilding = currentPos.Item2;
                string subString = currentPos.Item3;
                if (index >= s.Length || subString.Length == 3)
                {
                    //check 
                    if (subString == "101" || subString == "010")
                    {
                        stackValue.Add(1);
                    }
                    else
                    {
                        stackValue.Add(0);
                    }
                }
                else
                {
                    if (s[index] != prevBuilding)
                    {
                        stack.Push(new Tuple<int, char, string>(index + 1, s[index], subString + s[index]));
                        stack.Push(new Tuple<int, char, string>(index + 1, prevBuilding, subString));
                    }
                    else
                    {
                        stack.Push(new Tuple<int, char, string>(index + 1, prevBuilding, subString));
                    }
                }
                
            }
            return count;
        }

        Dictionary<Tuple<int, char, int>, int> mem; 
        public long NumberOfWays(string s)
        {
            mem = new Dictionary<Tuple<int, char, int>, int>();
            count = NumberOfWaysRec(s, 0, "", '-');
            return count;
        }
        long count = 0;
        int NumberOfWaysRec(string s, int index, string subString, char prevBuilding)
        {
            if (index >= s.Length || subString.Length == 3)
            {
                //check 
                if (subString == "101" || subString == "010")
                {
                    return 1;
                }
                return 0;

            }

            var pos = new Tuple<int, char, int>(index, prevBuilding, subString.Length);
            if (mem.ContainsKey(pos))
            {
                return mem[pos];
            }
            int tmp;
            if (s[index] != prevBuilding)
            {
                tmp = NumberOfWaysRec(s, index + 1, subString + s[index], s[index]) + NumberOfWaysRec(s, index + 1, subString, prevBuilding);
            }
            else
            {
                tmp = NumberOfWaysRec(s, index + 1, subString, prevBuilding);
            }


            mem[pos] = tmp;

            return tmp;
        }

        public long NumberOfWays2(string s)
        {
            int[] nextRestaurant = new int[s.Length]; // 1
            int[] nextOffice = new int[s.Length]; // 0
            int lastRes = -1;
            int lastOff = -1;
            for(int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '0')
                {
                    lastOff = i;
                }
                else
                {
                    lastRes = i;
                }
                nextOffice[i] = lastOff;
                nextRestaurant[i] = lastRes;
            }
            long ans = 0;
            for (int i = 0; i < s.Length; i++)
            {
                ans += FindNext(s, i, nextRestaurant, nextOffice);
            }
            return ans;
        }

        long FindNext(string s, int index, int[] nextRestaurant, int[] nextOffice)
        {
            long ans = 0;
            if (s[index] == '0')
            {
                // find next restaurant
                if (nextRestaurant[index] != -1)
                {
                    var nextOff = nextOffice[nextRestaurant[index]];
                    if (nextOff != -1)
                    {
                        ans += (nextOff - nextRestaurant[index]);
                        var next = FindNext(s, nextOff, nextRestaurant, nextOffice) ;
                        ans = ans + 2 * next + next;
                    }
                        
                }
            }
            else
            {
                // find next off
                if (nextOffice[index] != -1)
                {
                    var nextRes = nextRestaurant[nextOffice[index]];
                    if (nextRes != -1)
                    {
                        ans += (nextRes - nextOffice[index]);
                        var next = FindNext(s, nextRes, nextRestaurant, nextOffice);
                        ans = ans + ans * next + next;
                    }
                        
                }
            }
            return ans;
        }

    }
}
