using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class AccountsMergeSol
    {
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            Dictionary<string, string> emailToName = new Dictionary<string, string>();
            DSU dsu = new DSU();
            foreach (var account in accounts)
            {
                string accName = account[0];
                emailToName[account[1]] = accName;
                for (int i = 2; i < account.Count; i++)
                {
                    emailToName[account[i]] = accName;
                    dsu.Merge(account[i-1], account[i]);
                }
            }
            Dictionary<string, HashSet<string>> groups = new Dictionary<string, HashSet<string>>();
            HashSet<string> visited = new HashSet<string>();
            foreach (var kv in emailToName)
            {
                if (!visited.Contains(kv.Key))
                {
                    if (dsu.Parent.ContainsKey(kv.Key))
                    {
                        var root = dsu.FindEmail(kv.Key);
                        if (!groups.ContainsKey(root))
                        {
                            groups.Add(root, new HashSet<string>());
                        }
                        groups[root].Add(kv.Key);
                        var parent = dsu.Parent[kv.Key];
                        do
                        {
                            visited.Add(parent);
                            groups[root].Add(parent);
                            parent = dsu.Parent[parent];
                        }
                        while (dsu.Parent[parent] != parent);
                    }
                    else
                    {
                        // not in any group
                        groups.Add(kv.Key, new HashSet<string>(new string[] { kv.Key }));
                    }
                }
            }
            List<IList<string>> ans = new List<IList<string>>();
            foreach (var group in groups)
            {
                var emails = group.Value.ToList();
                emails.Sort(StringComparer.Ordinal);
                emails.Insert(0, emailToName[group.Key]);
                ans.Add(emails);
            }
            return ans;
        }

        class DSU
        {
            Dictionary<string, string> parent;

            public DSU()
            {
                parent = new Dictionary<string, string>();
            }

            public Dictionary<string, string> Parent { get => parent; }

            public string FindEmail(string email)
            {
                if (!parent.ContainsKey(email))
                    return null;
                if (parent[email] == email)
                    return email;
                return FindEmail(parent[email]);
            }

            public void Merge(string email1, string email2)
            {
                var a1 = FindEmail(email1);
                var a2 = FindEmail(email2);
                if (a1 == null && a2 == null)
                {
                    parent[email1] = email1;
                    parent[email2] = email1;
                } 
                else if (a1 != null && a2 == null)
                {
                    parent[email2] = a1;
                }
                else if (a1 == null && a2 != null)
                {
                    parent[email1] = a2;
                }
                else if (a1 != null && a2 != null)
                {
                    parent[a2] = a1;
                }
            }
        }
    }
}

