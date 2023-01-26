using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class SeatReservation
    {
        public int solution(int N, string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int count = 0;
            for (int i = 1; i <= N; i++)
            {
                count = count + reserve(i, S);
            }
            return count;
        }

        private int reserve(int row, string S)
        {
            string[] cases = new string[3];
            cases[0] = string.Format("{0}B {0}C {0}D {0}E", row);            
            cases[1] = string.Format("{0}F {0}G {0}H {0}J", row);
            cases[2] = string.Format("{0}D {0}E {0}F {0}G", row);
            if (checkAvailSeats(cases[0], S) && checkAvailSeats(cases[1], S))
            {
                return 2;
            } 
            else
            {
                foreach (var item in cases)
                {
                    if (checkAvailSeats(item, S))
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        private bool checkAvailSeats(string seatString, string S)
        {
            var seats = seatString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (seats.All(s => !S.Contains(s)))
            {
                return true;
            }
            return false;
        }
    }
}
