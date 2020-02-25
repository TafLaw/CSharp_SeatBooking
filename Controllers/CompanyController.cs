using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Csharp_Seat_Booking_System.Models;
using Csharp_Seat_Booking_System.Data;

namespace Csharp_Seat_Booking_System.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CsharpSeatBookingSystemContext _databaseConn;
        public CompanyController(CsharpSeatBookingSystemContext databaseConn)
        {
            _databaseConn = databaseConn;
        }

        public IActionResult AddVenue()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVenueToDb(AddVenue VenueInput)
        {
            VenueInput.VenueName = "TEST";
            VenueInput.AddVenueToDB(_databaseConn);
            return RedirectToAction("AddVenue", "Company");
        }

        public IActionResult AddEvent()
        {
            Venue[] Venues = _databaseConn.Venues.Where(a => a.CompanyId == 1).ToArray();
            ViewData["Venues"] = Venues;
            return View();
        }

        [HttpPost]
        public IActionResult AddEventToDb(Event EventInput)
        {
            EventInput.EventImg = "temp";
            EventInput.EventName = "d";
            EventInput.EventDesc = "3";
            _databaseConn.Add(EventInput);
            _databaseConn.SaveChanges();
            return RedirectToAction("AddEvent", "Company");
        }
    }
}

