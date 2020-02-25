using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Csharp_Seat_Booking_System.Models;
using Csharp_Seat_Booking_System.Services;
namespace Csharp_Seat_Booking_System.Controllers
{
    public class HomeController : Controller
    { 

            public JsonFileProductService ProductService { get; }
            public Product selectedProduct;
            public string selectedProductId { set; get; }
            public HomeController(JsonFileProductService productService)
            {
                this.ProductService = productService;
            }

            public IActionResult Index()
            {
                return View();
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

