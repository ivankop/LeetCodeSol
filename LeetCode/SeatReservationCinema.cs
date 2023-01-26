using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class SeatReservationCinema
    {
        private int[][] cases = new int[3][];
        HashSet<int> set1 = new HashSet<int>(new int[8] { 2, 3, 4, 5 , 6, 7, 8, 9 });
        HashSet<int> set2 = new HashSet<int>(new int[4] { 2, 3, 4, 5});
        HashSet<int> set3 = new HashSet<int>(new int[4] { 6, 7, 8, 9 });
        HashSet<int> set4 = new HashSet<int>(new int[4] { 4, 5, 6, 7 });

        public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
            cases[0] = new int[4] { 4, 5, 6, 7 };
            cases[1] = new int[4] { 2, 3, 4, 5 };
            cases[2] = new int[4] { 6, 7, 8, 9 };

            var dict = new Dictionary<int, List<int>>();
            
            for (int i = 0; i < reservedSeats.Length; i++)
            {
                if (dict.ContainsKey(reservedSeats[i][0]))
                {
                    dict[reservedSeats[i][0]].Add(reservedSeats[i][1]);
                }
                else
                {
                    List<int> list = new List<int>();
                    list.Add(reservedSeats[i][1]);
                    dict[reservedSeats[i][0]] = list;
                }
            }

            int count = 0;
            foreach (var kvp in dict)
            {
                var tmp = reserveRow(kvp.Value);
                //Console.WriteLine($"{i} - {tmp}");
                count = count + tmp;
            }
            var remain = n - dict.Count;
            count = count + remain * 2;
            /*
            for (int i = 1; i <= n; i++)
            {
                if (dict.ContainsKey(i))
                {
                    var tmp = reserveRow(dict[i]);
                    Console.WriteLine($"{i} - {tmp}");
                    count = count + tmp;
                }
                else
                {
                    count += 2;
                }
                
            }
            */
            return count;
        }

        private int reserveRow(List<int> seats)
        {
            if (checkSeats(set1, seats))
            {
                return 2;
            }
            else
            {
                if (checkSeats(set2, seats) || checkSeats(set3, seats) || checkSeats(set4, seats))
                {
                    return 1;
                }
            }
            return 0;
        }

        private bool checkSeats(int start, int end, List<int> seats)
        {
            foreach (var seat in seats)
            {
                if (seat >= start && seat <= end)
                {
                    return false;
                }
            }
            
            return true;
        }

        private bool checkSeats(HashSet<int> set, List<int> seats)
        {
            foreach (var seat in seats)
            {
                if (set.Contains(seat))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
