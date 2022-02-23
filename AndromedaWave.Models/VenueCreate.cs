using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models.VenueModels
{
    public class VenueCreate
    {
        [Required]
        public string VenueName { get; set; }
        [Required]
        public string VenueAddress { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Enter at least 1 character")]
        [MaxLength(5000, ErrorMessage = "Description can't exceed 5000 characters")]
        public string VenueDescription { get; set; }
    }
}
