using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csharp_Seat_Booking_System.Data;

namespace Csharp_Seat_Booking_System.Models
{
    public class SeatListForCart
    {
        public string SeatList { get; set; }
        public int EventID { get; set; }

        public string UserId { get; set; }

        public void AddSeatsToCart(CsharpSeatBookingSystemContext _databaseConn)
        {
            int i = 0;
            string[] SeatListArr = SeatList.Split(' ');
            foreach(string seat in SeatListArr)
            {
                Console.Out.WriteLine(seat);
                i++;
                Cart temp = new Cart();
                temp.SeatId = Int16.Parse(seat.Trim());
                temp.UserId = UserId;
                temp.EventId = EventID;
                _databaseConn.Add(temp);
                _databaseConn.SaveChanges();
            }
        }
    }
}
