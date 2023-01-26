using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public  class MinMeetingRoomsSol
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            List<Room> roomList = new List<Room>();

            intervals = intervals.OrderBy(i => i[0]).ToArray();

            var room = new Room(1);
            room.BookTime(intervals[0][0], intervals[0][1]);
            roomList.Add(room);

            for (int i = 1; i < intervals.GetLength(0); i++)
            {
                bool needNewRoom = true;
                for (int j = 0; j < roomList.Count; j++)
                {
                    if (intervals[i][0] >= roomList[j].LastBookedTime || CheckAvailableTime(roomList[j], intervals[i][0], intervals[i][1]))
                    {
                        roomList[j].BookTime(intervals[i][0], intervals[i][1]);
                        needNewRoom = false;
                        break;
                    }
                }
                // create new room
                if (needNewRoom)
                {
                    Console.WriteLine($"{intervals[i][0]}, {intervals[i][1]}");
                    var newRoom = new Room(roomList.Count + 1);
                    newRoom.BookTime(intervals[i][0], intervals[i][1]);
                    roomList.Add(newRoom);
                }
                
            }

            return roomList.Count;

        }

        private bool CheckAvailableTime(Room room, int start, int end)
        {
            foreach (var tuple in room.BookedTimes)
            {
                if (start <= tuple.Item1 && end > tuple.Item1)
                {
                    return false;
                }
                if (start >= tuple.Item1 && end <= tuple.Item2)
                {
                    return false;
                }
                if (start >= tuple.Item1 && start < tuple.Item2 && end >= tuple.Item2)
                {
                    return false;
                }
            }

            return true;
        }

        class Room
        {
            public Room(int id)
            {
                Id = id;
                BookedTimes = new List<Tuple<int, int>>();
                LastBookedTime = -1;
            }

            public int Id { get; set; }
            public List<Tuple<int, int>> BookedTimes { get; set; }
            public int LastBookedTime { get;set; }
            public void BookTime(int start, int end)
            {
                if (end > LastBookedTime)
                {
                    LastBookedTime = end;
                }
                BookedTimes.Add(new Tuple<int, int>(start,end));
            }

        }
    }
}
