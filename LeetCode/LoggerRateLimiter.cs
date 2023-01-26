using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Logger
    {
        Dictionary<string, int> loggers;
        public Logger()
        {
            loggers = new Dictionary<string, int>();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (!loggers.ContainsKey(message))
            {
                loggers.Add(message, timestamp + 10);
                return true;
            }
            else
            {
                if (timestamp >= loggers[message])
                {
                    loggers[message] = timestamp + 10;
                    return true;
                }
                return false;
            }

        }
    }
}
