using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class MaximalNetworkRanksol
    {
        Dictionary<int, CityNode> citiesDict = new Dictionary<int, CityNode>();
        public int MaximalNetworkRank(int n, int[][] roads)
        {
            
            for (int i = 0; i < roads.GetLength(0); i++)
            {
                CityNode node = null;
                CityNode neighborCity = null;
                if (!citiesDict.ContainsKey(roads[i][0]))
                {
                    node = new CityNode(roads[i][0]);
                    citiesDict[i] = node;
                }
                else
                {
                    node = citiesDict[roads[i][0]];
                }

                if (!citiesDict.ContainsKey(roads[i][1]))
                {
                    neighborCity = new CityNode(roads[i][1]);
                    citiesDict[neighborCity.Value] = neighborCity;
                }
                else
                {
                    neighborCity = citiesDict[roads[i][1]];
                }


                node.AddNeighbors(ref neighborCity);
                neighborCity.AddNeighbors(ref node);

            }

            int maxRank = 0;
            foreach (var city in citiesDict)
            {
                var rank = GetRank(city.Value);
                if (rank > maxRank)
                {
                    maxRank = rank;
                }
            }

            return maxRank > n ? n : maxRank;
        }

        private int GetRank(CityNode node)
        {
            Dictionary<Road, bool> visited = new Dictionary<Road, bool>();
            
            return Travel(node, visited);
        }

        private int Travel(CityNode node, Dictionary<Road, bool> visited)
        {
            int rank = 0;
            foreach (var city in node.Neighbors)
            {
                Road road = new Road(node, city);
                if (!visited.ContainsKey(road))
                {
                    visited.Add(road, true);
                    rank++;
                    rank += Travel(city, visited);
                }
            }
            return rank;
        }

        class CityNode
        {
            public CityNode(int val)
            {
                this.Value = val;
                Neighbors = new List<CityNode>();
            }

            public int Value { get; set; }

            public List<CityNode> Neighbors { get; set; }

            public void AddNeighbors(ref CityNode node)
            {
                if (!Neighbors.Contains(node))
                {
                    Neighbors.Add(node);
                }
            }

            public override bool Equals(object obj)
            {
                if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                else
                {
                    CityNode p = (CityNode)obj;
                    return (p.Value == Value);
                }
            }
        }

        class Road : IEquatable<Road>
        {
            public Road(CityNode city1, CityNode city2)
            {
                City1 = city1;
                City2 = city2;
            }

            public CityNode City1 { get; set; }
            public CityNode City2 { get; set; }

            public override bool Equals(object obj)
            {
                if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                else
                {
                    Road p = (Road)obj;
                    return (p.City1 == City1 && p.City2 == City2) || (p.City1 == City2 && p.City2 == City1);
                }
            }

            public bool Equals(Road p)
            {
                return (p.City1 == City1 && p.City2 == City2) || (p.City1 == City2 && p.City2 == City1);
            }

            public override int GetHashCode()
            {
                return 0; //Already an int
            }
        }
    }

    
}
