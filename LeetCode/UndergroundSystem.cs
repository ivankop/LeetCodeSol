using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class UndergroundSystem
    {
        Dictionary<int, Tuple<string, int>> userLogs;
        Dictionary<Tuple<string, string>, List<int>> trips;
        public UndergroundSystem()
        { 
            userLogs = new Dictionary<int, Tuple<string, int>>();
            trips = new Dictionary<Tuple<string, string>, List<int>> ();
        }

        public void CheckIn(int id, string stationName, int t)
        {
            userLogs.Add(id, Tuple.Create(stationName, t));
        }

        public void CheckOut(int id, string stationName, int t)
        {
            var duration = t - userLogs[id].Item2;
            var tripKey = new Tuple<string, string> (userLogs[id].Item1, stationName);
            if (!trips.ContainsKey(tripKey))
            {
                trips.Add(tripKey, new List<int>());
            }
            trips[tripKey].Add(duration);
            userLogs.Remove(id);
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            var tripKey = new Tuple<string, string>(startStation, endStation);
            if (trips.ContainsKey(tripKey))
            {
                var argTime = (double)trips[tripKey].Sum() / trips[tripKey].Count;
                return argTime;
            }
            return 0;
        }
    }
}
