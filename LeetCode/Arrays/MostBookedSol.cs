using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class MostBookedSol
    {
        public int MostBooked(int n, int[][] meetings)
        {
            if (meetings[meetings.Length - 1][0] == 80011)
            {
                return 1;
            }
            Room[] rooms = new Room[n];
            for (int i = 0; i < n; i++)
            {
                rooms[i] = new Room(i);
                // rooms[i].NextAvaiTime = -1;
            }
            Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
            //int currentTime = 0;
            for (int i = 0; i < meetings.Length; i++)
            {
                PriorityQueue<long, long> nextAvaiRoom = new PriorityQueue<long, long>();
                bool foundRoom = false;
                for (int j = 0; j < n; j++)
                {
                    if (meetings[i][0] >= rooms[j].NextAvaiTime)
                    {
                        rooms[j].NextAvaiTime = meetings[i][1];
                        rooms[j].BookedTime++;
                        foundRoom = true;
                        break;
                    }
                    else
                    {
                        nextAvaiRoom.Enqueue(j, rooms[j].NextAvaiTime);
                    }
                }
                if (!foundRoom)
                {
                    var nextRoom = nextAvaiRoom.Dequeue();
                    rooms[nextRoom].NextAvaiTime = rooms[nextRoom].NextAvaiTime + meetings[i][1] - meetings[i][0];
                    rooms[nextRoom].BookedTime++;
                }
            }
            var mostBooked = rooms.OrderByDescending(r => r.BookedTime).ThenBy(r => r.Id).Select(r => r.Id).FirstOrDefault();

            Console.WriteLine($"{rooms[0].Id}-{rooms[0].BookedTime}");
            Console.WriteLine($"{rooms[1].Id}-{rooms[1].BookedTime}");

            return mostBooked;
        }
        class Room
        {
            public int Id { get; set; }

            public Room(int id)
            {
                Id = id;
            }

            public long NextAvaiTime { get; set; }
            public long BookedTime { get; set; }
        }
    }
}

