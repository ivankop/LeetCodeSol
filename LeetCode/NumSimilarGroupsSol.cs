using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class NumSimilarGroupsSol
    {
        Dictionary<string, string> parent;
        HashSet<string> parents = new HashSet<string>();
        public int NumSimilarGroups(string[] strs)
        {
            HashSet<string> strSet = new HashSet<string>(strs);
            parent = new Dictionary<string, string>();
            parents = new HashSet<string>();
            foreach (string str in strs)
            {
                parent.Add(str, str);
            }
            int groupCount = strs.Length;
            foreach (string str in strSet)
            {
                //if (parent[str] == str)
                {
                    for (int i = 0; i < str.Length - 1; i++)
                    {
                        for (int j = i + 1; j < str.Length; j++)
                        {
                            var tmpStr = swap(str, i, j);
                            if (tmpStr != str && strSet.Contains(tmpStr))
                            {
                                Union(str, tmpStr);
                                // parent[tmpStr] = str;
                                groupCount--;
                            }
                        }
                    }
                    //groupCount++;   
                }
                
            }
            
            foreach (var str in strSet)
            {
                var p = FindParent(str);
                parents.Add(p);
            }
            return parents.Count;

        }

        string swap(string str, int left, int right)
        {
            var arr = str.ToCharArray();
            var tmp = arr[left];
            arr[left] = arr[right];
            arr[right] = tmp;
            var tmpStr = new string(arr);
            return tmpStr;
        }

        private string FindParent(string str)
        {
            if (parent[str] == str)
            {
                return str;
            }
            return FindParent(parent[str]);
        }

        private void Union(string f1, string f2)
        {
            string p1 = FindParent(f1);
            string p2 = FindParent(f2);
            if (p1 == p2)
                return;
            parent[p2] = p1;            
        }
    }
}
