using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Csharp_Seat_Booking_System.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please choose seats")]
        [Display(Name = "Seat ID")]
        public int SeatId { get; set; }

        [Required(ErrorMessage = "Please Login")]
        [Display(Name = "User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please Choose Event")]
        [Display(Name = "Event ID")]
        public int EventId { get; set; }

    }
}
