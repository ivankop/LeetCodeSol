using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TimeMap
    {
        Dictionary<string, SortedList<int, string>> map;
        public TimeMap()
        {
            map = new Dictionary<string, SortedList<int, string>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (!map.ContainsKey(key))
            {
                map[key] = new SortedList<int, string>();
                
            }
            map[key].Add(timestamp, value);
        }

        public string Get(string key, int timestamp)
        {
            if (!map.ContainsKey(key) || timestamp < map[key].Keys[0])
            {
                return "";
            }

            // var value = map[key].Where(x => timestamp >= x.Key).OrderByDescending( x => x.Key).Select(x => x.Value).FirstOrDefault();
            var nearest = BinarySearch(map[key].Keys, timestamp);
            
            if (!map[key].ContainsKey(nearest))
            {
                return "";
            }
            return map[key][nearest];
        }

        public int BinarySearch(IList<int> a, int item)
        {
            int lower = 0;
            int upper = a.Count - 1;
            int index = (lower + upper) / 2;
            while (lower <= upper)
            {
                if (a[index] == item)
                    return index;
                
                if (a[index] < item) 
                {
                    lower = index + 1;
                    
                }
                else 
                {
                    upper = index - 1;
                }

                index = (lower + upper) / 2;
            }
            return index;
        }


    }
}
