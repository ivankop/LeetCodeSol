using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class RangeModule
    {
        SortedList<int, int> ranges;
        public RangeModule()
        {
            ranges = new SortedList<int, int>();
        }

        public void AddRange(int left, int right)
        {
            if (ranges.ContainsKey(left))
            {
                if( ranges[left] < right )
                    ranges[left] = right;
            }
            else
            {
                ranges.Add(left, right);
            }
            Merge();
        }

        private void Merge()
        {
            SortedList<int, int> newRanges = new SortedList<int, int>();
            newRanges.Add(ranges.Keys[0], ranges[ranges.Keys[0]]);
            for (int i = 1; i < ranges.Count; i++)
            {
                var tmpKey = ranges.Keys[i];
                var lastKey = newRanges.Keys[newRanges.Count - 1];
                if (tmpKey <= newRanges[lastKey])
                {
                    newRanges[lastKey] = Math.Max(ranges[tmpKey], newRanges[lastKey]);
                }
                else
                {
                    newRanges.Add(tmpKey, ranges[tmpKey]);
                }
            }
            ranges = newRanges;
        }

        public bool QueryRange(int left, int right)
        {
            foreach (var range in ranges)
            {
                if (left >= range.Key && right <= range.Value)
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveRange(int left, int right)
        {
            SortedList<int, int> newRanges = new SortedList<int, int>();
            //newRanges.Add(ranges.Keys[0], ranges[ranges.Keys[0]]);
            for (int i = 0; i < ranges.Count; i++)
            {

                var tmpKey = ranges.Keys[i];
                // outside
                if (right < tmpKey || left > ranges[tmpKey])
                {
                    newRanges.Add(tmpKey, ranges[tmpKey]);
                    continue;
                }
                if (left <= tmpKey && right >= ranges[tmpKey])
                {
                    // remove current range
                    continue;
                }
                // left
                if (left <= tmpKey && right < ranges[tmpKey])
                {
                    newRanges.Add(right, ranges[tmpKey]);
                }
                // right
                if (left >= tmpKey && right >= ranges[tmpKey])
                {
                    newRanges.Add(tmpKey, left);
                }
                // middle
                if (left > tmpKey && right < ranges[tmpKey])
                {
                    newRanges.Add(tmpKey, left);
                    newRanges.Add(right, ranges[tmpKey]);
                }
            }
            ranges = newRanges;
        }

        class RangeNode
        {
            public int left;
            public int right;
            public RangeNode leftNode;
            public RangeNode rightNode;

            public RangeNode(int left, int right)
            {
                this.left = left;
                this.right = right;
            }
        }
    }
}
