using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Csharp_Seat_Booking_System.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Venue Id")]
        public string EventName { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Seat Type")]
        public string EventImg { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Seat x")]
        public string EventDesc { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Seat y")]
        public int VenueId { get; set; }
    }
}
