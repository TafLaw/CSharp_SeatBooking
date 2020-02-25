using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Venue
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int VenueId { get; set; }

	[Required(ErrorMessage = "Please name your using Venue")]
	[Display(Name = "Venue Name")]
	public string Name { get; set; }

	[Required(ErrorMessage = "Please name your using Venue")]
	[Display(Name = "Venue Name")]
	public int CompanyId { get; set; }
}
