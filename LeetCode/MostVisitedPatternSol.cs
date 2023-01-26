using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class MostVisitedPatternSol
    {
        public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
        {
            Dictionary<string, List<Pair>> userAccessDict = new Dictionary<string, List<Pair>>();
            for (int i = 0; i < username.Length; i++)
            {
                if (!userAccessDict.ContainsKey(username[i]))
                {
                    var websiteList = new List<Pair>();
                    websiteList.Add(new Pair { Timestamp = timestamp[i], WebSite = website[i] });
                    userAccessDict.Add(username[i], websiteList);
                }
                else
                {
                    userAccessDict[username[i]].Add(new Pair { Timestamp = timestamp[i], WebSite = website[i] });
                }    
            }
            Dictionary<string, int> patternScore = new Dictionary<string, int>();
            int maxScore = 0;
            string maxKey = string.Empty;
            List<string> res = new List<string>();
            foreach (var item in userAccessDict)
            {
                var visitedWebSite = item.Value.OrderBy(w => w.Timestamp).Select(i => i.WebSite).ToList();
                CalculatePatternScore(visitedWebSite, patternScore, ref maxScore, ref maxKey, res);
            }
            return res;
        }

        private void CalculatePatternScore(List<string> websiteList, Dictionary<string, int> patternScore, ref int maxScore, ref string maxKey, List<string> res)
        {
            List<string> userKey = new List<string>();
            for (int i = 0; i < websiteList.Count - 2; i++)
            {
                for (int j = i + 1; j < websiteList.Count - 1; j++)
                {
                    for (int k = j + 1; k < websiteList.Count; k++)
                    {
                        var key = $"{websiteList[i]}+{websiteList[j]}+{websiteList[k]}";
                        if (!userKey.Contains(key))
                        {
                            if (patternScore.ContainsKey(key))
                            {
                                patternScore[key] += 1;
                            }
                            else
                            {
                                patternScore[key] = 1;
                            }

                            if (patternScore[key] > maxScore || (patternScore[key] == maxScore && string.Compare(key, maxKey) == -1))
                            {
                                maxScore = patternScore[key];
                                maxKey = key;
                                res.Clear();
                                res.Add(websiteList[i]);
                                res.Add(websiteList[j]);
                                res.Add(websiteList[k]);
                            }
                            userKey.Add(key);
                        }
                        
                    }
                }
            }
        }

        class Pair
        {
            public string WebSite { get; set; }
            public int Timestamp { get; set; }
        }

    }
}
