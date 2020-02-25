using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csharp_Seat_Booking_System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Csharp_Seat_Booking_System.Models
{
	public class AddVenue
	{
		[DataType(DataType.Text)]
		public string VenueName { get; set; }
        public string Map { get; set; }
		public int CompanyId { get; set; }

		public void AddVenueToDB(CsharpSeatBookingSystemContext _databaseConn)
		{
			Venue SaveVenue = new Venue();
			SaveVenue.Name = VenueName;
			SaveVenue.CompanyId = 1;
			_databaseConn.Add(SaveVenue);
			_databaseConn.SaveChanges();
			List<Seat> ListOfSeats = MapToList(Map, SaveVenue.VenueId);
			foreach (Seat SeatInList in ListOfSeats)
			{
				_databaseConn.Add(SeatInList);
			}
			_databaseConn.SaveChanges();
		}

		public List<Seat> MapToList(string map, int VenueID)
		{
			char[] seperator = { '\n' };
			Console.Out.Write(map);
			string[] FileArr = map.Split(seperator);
			Console.Out.WriteLine(FileArr);
			int LineIndex = 0;
			int CharIndex = 0;
			List<Seat> VenueLayout = new List<Seat>();

			foreach (string LineInFile in FileArr)
			{
				char[] CharArr = LineInFile.Trim().ToCharArray();
				CharIndex = 0;
				foreach (char CharInLine in CharArr)
				{
					if (CharInLine != '0')
					{
						Seat temp = new Seat();
						temp.SeatCatergory = CharInLine - '0';
						temp.SeatXCordinate = CharIndex;
						temp.SeatYCordinate = LineIndex;
						temp.VenueId = VenueID;
						VenueLayout.Add(temp);
					}
					CharIndex++;
				}
				LineIndex++;
			}
			return VenueLayout;
		}
	}
}
