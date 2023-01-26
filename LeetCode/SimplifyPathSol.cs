using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SimplifyPathSol
    {
        public string SimplifyPath(string path)
        {
            var folders = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            int parentSkip = 0;
            StringBuilder newPath = new StringBuilder();
            for (int i = folders.Length - 1; i >= 0; i--)
            {
                if (folders[i] != "." && folders[i] != "..")
                {
                    if( parentSkip > 0)
                    {
                        parentSkip--;
                        continue;
                    }
                    newPath.Insert(0, folders[i]);
                    newPath.Insert(0, "/");
                }
                else if (folders[i] == "..")
                {
                    parentSkip++;
                    //break;
                }
            }

            var tmp = newPath.ToString();
            if (string.IsNullOrEmpty(tmp))
                return "/";
            return tmp;
        }
    }
}
