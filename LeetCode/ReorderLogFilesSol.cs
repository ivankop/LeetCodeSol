using System;
using System.Collections.Generic;
using System.Linq;

namespace RottingOranges
{
    public class ReorderLogFilesSol
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            List<Pair> letterLogs = new List<Pair>();
            List<string> digitLogs = new List<string>();

            foreach (var item in logs)
            {
                var words = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var key = words[0];
                var isDigit = Char.IsDigit(words[1][0]);
                words.RemoveAt(0);
                if (isDigit)
                {
                    digitLogs.Add(item);

                }
                else
                {
                    letterLogs.Add(new Pair { Id = key, Log = string.Join(" ", words) });
                }
            }
            var letterLogList = letterLogs.OrderBy(kv => kv.Log).ThenBy(kv => kv.Id).Select(kv => kv.Id + " " + kv.Log).ToList();
            // var digitLogsList = digitLogs.Select(kv => kv.Key + " " + kv.Value).ToList();

            letterLogList.AddRange(digitLogs);
            return letterLogList.ToArray();
        }

        class Pair
        {
            public string Id { get; set; }
            public string Log { get; set; }
        }
    }
}
