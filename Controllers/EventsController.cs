using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Csharp_Seat_Booking_System.Models;
using Csharp_Seat_Booking_System.Services;
using Csharp_Seat_Booking_System.Data;
using System.Data.SqlClient;

namespace Csharp_Seat_Booking_System.Controllers
{
    public class EventsController : Controller
    {
        private readonly CsharpSeatBookingSystemContext _databaseConn;
        public JsonFileProductService ProductService { get; }
        public EventsController(JsonFileProductService  productService, CsharpSeatBookingSystemContext databaseConn)
        {
            _databaseConn = databaseConn;
            this.ProductService = productService;
        }

        public IActionResult ViewEvents(){
            ViewData["events"] = this.ProductService.GetProducts();
            return View();
        }

        public IActionResult AddEvent(){
            return View();
        }

        [Route("/Event/SeatSelection/{EventId}")]
        public IActionResult SeatSelection(int EventId){
            //must be get to get the movie being booked
            var EventInfo = _databaseConn.Events.Single(a => a.EventId == EventId);
            Seat[] Seats = _databaseConn.Seats.Where(p => p.VenueId == EventInfo.VenueId).ToArray();
            ViewData["arr"] = Seats;
            ViewData["eventId"] = EventId;

            return View();
        }

        [HttpGet("/Events/ViewEvent/{id}")]
        public IActionResult GetEvent(int id)
        {
            ViewData["index"] = id;
            return View();
        }

        [HttpPost]
        [Route("api/addToCart")]
        public IActionResult AddSeatsToCart(SeatListForCart listOfSeats)
        {
            
            if (listOfSeats == null)
            {
                return RedirectToAction("ViewCart", "Checkout");
            }

            listOfSeats.AddSeatsToCart(_databaseConn);
            return RedirectToAction("ViewCart", "Checkout");
        }
    }
}