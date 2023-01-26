using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class CountServersSol
    {
        public int CountServers(int[][] grid)
        {
            List<Tuple<int, int>> servers = new List<Tuple<int, int>>();    
            // row
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                int connectedIndex = -1;
                bool rowConnected = false;
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] > 0)
                    {
                        if (connectedIndex < 0)
                        {
                            connectedIndex = j;
                        }
                        else
                        {
                            if (!rowConnected)
                            {
                                AddToConnectedServerList(servers, new Tuple<int, int>(i, connectedIndex));
                                rowConnected = true;    
                            }
                            AddToConnectedServerList(servers, new Tuple<int, int>(i, j));
                        }
                        
                    }
                }
            }

            // column
            for (int i = 0; i < grid[0].Length; i++)
            {
                int connectedIndex = -1;
                bool colConnected = false;
                for (int j = 0; j < grid.GetLength(0); j++)
                {
                    if (grid[j][i] > 0)
                    {
                        if (connectedIndex < 0)
                        {
                            connectedIndex = j;
                        }
                        else
                        {
                            if (!colConnected)
                            {
                                AddToConnectedServerList(servers, new Tuple<int, int>(connectedIndex, i));
                                colConnected = true;
                            }
                            AddToConnectedServerList(servers, new Tuple<int, int>(j, i));
                        }

                    }
                }
            }

            return servers.Count;
        }

        private void AddToConnectedServerList(List<Tuple<int, int>> servers, Tuple<int, int> server)
        {
            if (!servers.Contains(server))
            {
                servers.Add(server);
            }
        }
    }
}
