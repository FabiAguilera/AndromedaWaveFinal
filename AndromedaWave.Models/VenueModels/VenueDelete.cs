using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models.VenueModels
{
    public class VenueDelete
    {
        [Required]
        public int VenueId { get; set; }
    }
}
