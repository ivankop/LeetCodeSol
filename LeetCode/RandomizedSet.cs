using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class RandomizedSet
    {
        SortedList<int, int> list;
        public RandomizedSet()
        {
            list = new SortedList<int, int>();
        }

        public bool Insert(int val)
        {
            if (list.ContainsKey(val))
            {
                return false;
            }
            list.Add(val, val);
            return true;
        }

        public bool Remove(int val)
        {
            if (list.ContainsKey(val))
            {
                list.Remove(val);
                return true;
            }
            
            return false;
        }

        public int GetRandom()
        {
            var rand = new Random();
            int index = rand.Next(list.Count + 1);
            return list.Keys[index];
        }
    }
}
