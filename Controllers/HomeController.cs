using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Csharp_Seat_Booking_System.Models;
using Csharp_Seat_Booking_System.Services;
using Database.Connect;
using System.Data;
using System.Data.SqlClient;


namespace Csharp_Seat_Booking_System.Controllers
{
    public class HomeController : Controller
    { 
            private ConnDatabase connect;
            public static string Name;
            public JsonFileProductService ProductService { get; }
            public Product selectedProduct;
            public string selectedProductId { set; get; }
            public HomeController(JsonFileProductService productService)
            {
                this.ProductService = productService;
            }

            public IActionResult Index()
            {
                Console.WriteLine(LoginController.sessionState);
                return View();
            }

            public IActionResult MovieBoard()
            {
                connect = new ConnDatabase();
                string connectionString = "Data Source=TafadzwaMu;Initial Catalog=SeatBooking;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);
                //connect.sqlQuery("SELECT COUNT(*) FROM[SeatBooking].[dbo].[Seat] WHERE SeatNumber = 2; ");

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*)as numberofrows FROM[SeatBooking].[dbo].[Seat] WHERE SeatNumber = 2; ", conn);

                conn.Open();

                int count = (int)cmd.ExecuteScalar();
                //connect.NonExecute();
                return View(count);
            }


            [HttpGet] //response.
            public IEnumerable<Product> Get()
            {
                return this.ProductService.GetProducts();
            }

            //[HttpPatch] "fromBody"
            [Route("Rate")]
            [HttpGet]
            public ActionResult Get([FromQuery] string ProductId, [FromQuery] int Rating)
            {
                ProductService.AddRating(ProductId, Rating);
                return Ok();

            }
            
            [HttpPost]
            public IActionResult AllSeats([Bind("ProductName")]Seat product)
            {
                Name = product.ProductName;
                // Console.WriteLine("hrer");
                // Console.WriteLine(product.ProductName);
                return Redirect("../Events/AllSeats");
            }


            [Route("First")]
            [HttpGet]
            public ActionResult Get([FromQuery] string productId)
            {
                selectedProductId = productId;
                selectedProduct = ProductService.GetProducts().First(x => x.Id == productId);
                return Ok();
            }
        }
    }

