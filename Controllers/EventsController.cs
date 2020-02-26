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
using Database.Connect;


namespace Csharp_Seat_Booking_System.Controllers
{
    public class EventsController : Controller
    {
        
        private ConnDatabase connect;
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

        public IActionResult AllSeats()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Book([Bind("SeatId","VenueId", "SeatCatergory", "SeatXCordinate", "SeatYCordinate")]Seat result)
        {
            connect = new ConnDatabase();
            connect.sqlQuery("INSERT INTO Seat (UserID, VenueID, SeatNumber, SeatCatergory, SeatXCordinate, SeatYCordinate) Values('"+ 1 +"', '"+ result.VenueId+ "','"+ result.SeatCatergory +"', '"+ result.SeatCatergory+ "','"+ result.SeatXCordinate +"', '"+ result.SeatYCordinate+ "')");
            connect.NonExecute();
            return View("AllSeats");
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