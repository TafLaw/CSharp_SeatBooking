using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Csharp_Seat_Booking_System.Models
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatId { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Venue Id")]
        public int VenueId { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Seat Type")]
        public int SeatCatergory { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Seat x")]
        public int SeatXCordinate { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Seat y")]
        public int SeatYCordinate { get; set; }
    }
}